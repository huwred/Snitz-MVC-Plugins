using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using WebGrease.Css.Extensions;

namespace SnitzEvents.Helpers
{
    public static class HtmlHelperExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public static DateTime WithTime(this DateTime date, TimeSpan time)
        {
            return date.Date + time;
        }

        /// <summary>
        /// Copy a DateTime to new dateTime keeping the existing date
        /// </summary>
        /// <param name="original"></param>
        /// <param name="newDate"></param>
        /// <returns></returns>
        public static DateTime WithDate(this DateTime original, DateTime newDate)
        {
            return newDate.WithTime(original);
        }

        /// <summary>
        /// Copies the newTime to the original Date
        /// </summary>
        /// <param name="original"></param>
        /// <param name="newTime"></param>
        /// <returns></returns>
        public static DateTime WithTime(this DateTime original, DateTime newTime)
        {
            return original.Date + newTime.TimeOfDay;
        }
        public static DateTime WithYear(this DateTime original, DateTime newDate)
        {
            DateTime value = new DateTime(newDate.Year, original.Month, original.Day,original.Hour,original.Minute,0);
            return value;
        }
        /// <summary>
        /// Creates a dropdown list for an Enum property
        /// </summary>
        /// <exception cref="System.ArgumentException">If the property type is not a valid Enum</exception>
        public static MvcHtmlString EnumDropDownListFor<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TEnum>> expression, string emptyItemText = "", string emptyItemValue = "", object htmlAttributes = null)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            Type enumType = GetNonNullableModelType(metadata);
            var values = Enum.GetValues(enumType).Cast<TEnum>();

            IEnumerable<SelectListItem> items = from value in values
                                                select new SelectListItem
                                                {
                                                    Text = LangResources.Utility.ResourceManager.GetLocalisedString(value.GetType().Name + "_" + value),
                                                    Value = value.ToString(),
                                                    Selected = value.Equals(metadata.Model)
                                                };

            // If the enum is nullable, add an 'empty' item to the collection
            if (metadata.IsNullableValueType)
                items = SingleEmptyItem.Concat(items);

            return htmlHelper.DropDownListFor(expression, items, htmlAttributes);

        }
        /// <summary>
        /// Creates a checkbox list for an Enum property
        /// </summary>
        public static MvcHtmlString EnumCheckBoxListFor<TModel, TEnum>(this HtmlHelper<TModel> html, Expression<Func<TModel, IEnumerable<TEnum>>> expression, object htmlAttributes = null)
        {
            return html.CheckBoxListFor(expression, GetEnumSelectList<TEnum>(), htmlAttributes);
        }

        /// <summary>
        /// Returns a checkbox for each of the provided <paramref name="items"/>.
        /// </summary>
        public static MvcHtmlString CheckBoxListFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, IEnumerable<SelectListItem> items, object htmlAttributes = null)
        {
            var listName = ExpressionHelper.GetExpressionText(expression);
            var metaData = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);

            items = GetCheckboxListWithDefaultValues(metaData.Model, items);
            return htmlHelper.CheckBoxList(listName, items, htmlAttributes);
        }

        /// <summary>
        /// Returns a checkbox for each of the provided <paramref name="items"/>.
        /// </summary>
        public static MvcHtmlString CheckBoxList(this HtmlHelper htmlHelper, string listName, IEnumerable<SelectListItem> items, object htmlAttributes = null)
        {
            var outer = new TagBuilder("div");
            var container = new TagBuilder("div");
            container.MergeAttribute("class", "col-xs-6");
            var cnt = 0;
            foreach (var item in items)
            {
                cnt++;
                var container2 = new TagBuilder("div");
                container2.MergeAttribute("class", "checkbox"); // default class
                var label = new TagBuilder("label");
                //label.MergeAttribute("class", "checkbox"); // default class
                

                var cb = new TagBuilder("input");
                cb.MergeAttribute("type", "checkbox");
                cb.MergeAttribute("name", listName);
                cb.MergeAttribute("value", item.Value ?? item.Text);
                cb.MergeAttributes(new RouteValueDictionary(htmlAttributes), true);
                if (item.Selected)
                    cb.MergeAttribute("checked", "checked");

                label.InnerHtml = cb.ToString(TagRenderMode.SelfClosing) + item.Text;

                container2.InnerHtml += label.ToString();
                container.InnerHtml += container2.ToString();
                if (cnt == 4)
                {
                    outer.InnerHtml += container.ToString();
                    container = new TagBuilder("div");
                    container.MergeAttribute("class", "col-xs-6");
                }
            }
            outer.InnerHtml += container.ToString();
            return new MvcHtmlString(outer.ToString());
        }

        private static IEnumerable<SelectListItem> GetEnumSelectList<TEnum>(bool addEmptyItemForNullable = false, string emptyItemText = "", string emptyItemValue = "")
        {
            var enumType = typeof(TEnum);
            var nullable = false;

            if (!enumType.IsEnum)
            {
                enumType = Nullable.GetUnderlyingType(enumType);

                if (enumType != null && enumType.IsEnum)
                {
                    nullable = true;
                }
                else
                {
                    throw new ArgumentException("Not a valid Enum type");
                }
            }

            var selectListItems = (from v in Enum.GetValues(enumType).Cast<TEnum>()
                                   select new SelectListItem
                                   {
                                       Text = v.ToString(),
                                       Value = v.ToString()
                                   }).ToList();

            if (nullable && addEmptyItemForNullable)
            {
                selectListItems.Insert(0, new SelectListItem { Text = emptyItemText, Value = emptyItemValue });
            }

            return selectListItems;
        }

        private static IEnumerable<SelectListItem> GetCheckboxListWithDefaultValues(object defaultValues, IEnumerable<SelectListItem> selectList)
        {
            var defaultValuesList = defaultValues as IEnumerable;

            if (defaultValuesList == null)
                return selectList;

            IEnumerable<string> values = from object value in defaultValuesList
                                         select Convert.ToString(value, CultureInfo.CurrentCulture);

            var selectedValues = new HashSet<string>(values, StringComparer.OrdinalIgnoreCase);
            var newSelectList = new List<SelectListItem>();

            selectList.ForEach(item =>
            {
                item.Selected = (item.Value != null) ? selectedValues.Contains(item.Value) : selectedValues.Contains(item.Text);
                newSelectList.Add(item);
            });

            return newSelectList;
        }
        #region Private helper methods
        private static Type GetNonNullableModelType(ModelMetadata modelMetadata)
        {
            Type realModelType = modelMetadata.ModelType;

            Type underlyingType = Nullable.GetUnderlyingType(realModelType);
            if (underlyingType != null)
            {
                realModelType = underlyingType;
            }
            return realModelType;
        }

        private static readonly SelectListItem[] SingleEmptyItem = new[] { new SelectListItem { Text = "", Value = "" } };

        #endregion
    }
}

