using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LangResources.Utility;
using MemberFields.Models;
using SnitzDataModel.Controllers;
using SnitzMembership;


namespace MemberFields.Controllers
{

    public class MemberFieldsController : BaseController
    {
        #region Admin

        /// <summary>
        /// Returns MemberFields Admin View
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Administrator")]
        public ActionResult Admin()
        {
            var vm = MemberFieldsRepository.GetFields();
            return View("Admin", vm);
        }
        [Authorize(Roles = "Administrator")]
        public ActionResult Enable()
        {
            return PartialView("_Enable");
        }
        /// <summary>
        /// Display MemberFields Create Form
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public PartialViewResult FieldCreate()
        {

            return PartialView("_FieldCreateEdit", new ExtendedProfile());

        }

        /// <summary>
        /// Display MemberFields Edit Form
        /// </summary>
        /// <param name="id">ID of field to edit</param>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public PartialViewResult FieldEdit(int id)
        {
            var vm = MemberFieldsRepository.GetField(id);
            //if (vm.FieldType.Contains("select"))
            //{
            //    vm.Options = MemberFieldsRepository.GetFieldOptions(id);
            //}
            return PartialView("_FieldCreateEdit", vm);

        }

        /// <summary>
        /// Save the Extend Field
        /// </summary>
        /// <param name="vm">ExtendedProfile</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public PartialViewResult FieldCreateEdit(ExtendedProfile vm)
        {
            MemberFieldsRepository.CreateField(vm);
            //if (vm.FieldType.EndsWith("select"))
            //{
            //    var names = Request.Form.GetValues("OptName");
            //    var orders = Request.Form.GetValues("OptOrder");
            //    if (names.Any())
            //    {
            //        MemberFieldsRepository.SaveOptions(vm.Id,names, orders);
            //    }
            //}
            return PartialView("_FieldCreateEdit", new ExtendedProfile());

        }

        /// <summary>
        /// Delete MemberField
        /// </summary>
        /// <param name="id">ID of field to delete</param>
        /// <returns></returns>
        [Authorize(Roles = "Administrator")]
        public ActionResult FieldDelete(int id)
        {
            try
            {
                MemberFieldsRepository.DeleteField(id);
                return Redirect(Request.UrlReferrer.ToString());

            }
            catch (Exception)
            {
                ViewBag.Error = ResourceManager.GetLocalisedString("InvalidID", "ErrorMessage");
                return View("Error");
            }
            
        }
        #endregion

        #region Profile

        /// <summary>
        /// Fetch all extended Properties of a Member
        /// </summary>
        /// <param name="id">ID of Member</param>
        /// <param name="exclude">List of properties to exclude</param>
        /// <returns></returns>
        public ActionResult MemberFieldsAll(int id, string[] exclude = null)
        {
            if (MemberManager.GetUser(id) != null)
            {
                if (exclude == null)
                {
                    return PartialView("_ExProfilesView", MemberFieldsRepository.GetValues(id));
                }
                else
                {
                    return PartialView("_ExProfilesView", MemberFieldsRepository.GetValuesExcluded(id,exclude));
                }
            }

            return View("Error");
        }
        /// <summary>
        /// Fetch extended Properties of a Member
        /// </summary>
        /// <param name="id">ID of Member</param>
        /// <param name="properties">List of properties to include</param>
        /// <returns></returns>
        public ActionResult MemberFields(int id,string[] properties)
        {
            if (MemberManager.GetUser(id) != null)
                return PartialView("_ExProfilesView", MemberFieldsRepository.GetValues(id, properties));

            return View("Error");
        }
        /// <summary>
        /// Fetch a specific extended property of a Member
        /// </summary>
        /// <param name="id">ID of Member</param>
        /// <param name="property">Property to Display</param>
        /// <returns></returns>
        public PartialViewResult MemberField(int id, string property)
        {

            KeyValuePair<int, string> vm = new KeyValuePair<int, string>(id, property);
            var pVal = MemberFieldsRepository.GetValue(id, property);

            return PartialView("_ExProfileView", pVal);

        }

        /// <summary>
        /// Gets all extended properties for a Member to Edit
        /// </summary>
        /// <param name="id">ID of Member</param>
        /// <param name="exclude">List of properties to exclude</param>
        /// <returns></returns>
        [Authorize]
        public ActionResult MemberFieldsEdit(int id, string[] exclude = null)
        {
            if (MemberManager.GetUser(id) != null)
            {
                if (exclude == null)
                {
                    return PartialView("_ExProfilesEdit", MemberFieldsRepository.GetValues(id));
                }
                else
                {
                    return PartialView("_ExProfilesEdit", MemberFieldsRepository.GetValuesExcluded(id, exclude));
                }

            }
            return View("Error");
        }
        /// <summary>
        /// Edit a specific extended property of a Member
        /// </summary>
        /// <param name="id">ID of Member</param>
        /// <param name="property">Name of property to Edit</param>
        /// <returns></returns>
        [Authorize]
        public PartialViewResult MemberFieldEdit(int id, string property)
        {

            KeyValuePair<int, string> vm = new KeyValuePair<int, string>(id, property);
            var pVal = MemberFieldsRepository.GetValue(id, property);

            return PartialView("_ExProfileEdit", pVal);

        }

        /// <summary>
        /// Save Extended Property for a Member
        /// </summary>
        /// <param name="id">ID of Member</param>
        /// <param name="property">Name of Property to save</param>
        /// <param name="value">Value to save</param>
        /// <returns></returns>
        [Authorize]
        public ActionResult SaveProfile(int id, string property, string value)
        {
            try
            {
                MemberFieldsRepository.SaveValue(id, property, Request.Form["value"]);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
                //return Json(new { success = false, errors = ex.Message }, JsonRequestBehavior.AllowGet);
            }

            MemberProfile pVal = (MemberProfile) MemberFieldsRepository.GetValue(id, property);

            return PartialView("_ExProfileEdit", pVal);

        }

        #endregion

    }
}
