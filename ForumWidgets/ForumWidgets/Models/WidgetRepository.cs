using System;
using System.Collections.Generic;
using System.Linq;
using SnitzDataModel.Database;


namespace ForumWidgets.Models
{
    public class WidgetRepository : IDisposable
    {
        private List<ForumWidget> _data;

        public int Pagecount;
        public int Pagesize;

        public WidgetRepository(int pagesize = 10)
        {
            Pagesize = pagesize;
            Initialize();
        }
        private void Initialize()
        {
            _data = new List<ForumWidget>();

            using (var context = new SnitzDataContext())
            {
                _data = context.Fetch<ForumWidget>("SELECT * FROM FORUM_WIDGETS ORDER BY W_NAME");

            }
            Pagecount = _data.Count / Pagesize;

            if ((_data.Count % Pagesize) != 0)
                Pagecount++;
        }

        public ForumWidget GetById(int id)
        {
            ForumWidget b = _data.FirstOrDefault(c => c.Id == id);
            return b;
        }
        public List<ForumWidget> GetAllWidgets()
        {
            return _data.OrderByDescending(c => c.Id).ToList();
        }
        public List<ForumWidget> GetPaged(int pagenum)
        {
            using (var context = new SnitzDataContext())
            {
                return context.Page<ForumWidget>(pagenum, Pagesize, "ORDER BY W_NAME").Items;

            }

        }
        public bool AddForumWidget(string name, string html)
        {
            var widget = new ForumWidget();
            widget.Name = name;
            widget.HtmlString = html;

            using (var context = new SnitzDataContext())
            {
                return context.Insert(widget) != null;
            }
        }
        public bool DeleteWidget(int id)
        {
            using (var context = new SnitzDataContext())
            {
                return context.Delete<ForumWidget>(id) > 0;
            }
        }

        public void Dispose()
        {
            _data.Clear();
            _data = null;
        }

        public void SaveWidget(ForumWidget widget)
        {
            using (var context = new SnitzDataContext())
            {
                context.Update("FORUM_WIDGETS", "W_ID", widget);
            }
        }

        public string GetByName(string name)
        {
            using (var context = new SnitzDataContext())
            {
                return context.FirstOrDefault<string>("SELECT W_HTML FROM FORUM_WIDGETS WHERE W_NAME=@0", name);
            }
        }
    }

}