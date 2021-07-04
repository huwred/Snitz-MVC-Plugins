using System;
using System.Collections.Generic;
using PetaPoco;
using SnitzDataModel.Database;



namespace ImageComments.Models
{
    public class CommentRepository : IDisposable
    {
        //private List<AlbumImage> _data;
        private int _memberid;
        public long Pagecount;
        public int Pagesize;

        public CommentRepository(int memberid=0, int pagesize = 30)
        {
            _memberid = memberid;
            Pagesize = pagesize;
            
            //if(memberid >= 0)
            //    Initialize();
        }


        public void Dispose()
        {
            //if (_data != null)
            //{
            //    _data.Clear();
            //    _data = null;
            //}
        }

        public List<ImageComment> GetComments(int id)
        {

            using (var context = new SnitzDataContext())
            {
                Sql sql = new Sql();
                sql.Select("com.*, m.M_NAME AS PostedBy");
                sql.From(context.ForumTablePrefix + "IMAGE_COMMENT com");
                sql.LeftJoin(context.MemberTablePrefix + "MEMBERS m").On("com.I_MEMBERID=m.MEMBER_ID");
                sql.Where("I_IMGID=@0", id);
                sql.OrderBy("I_DATE DESC");

                return context.Fetch<ImageComment>(sql);

            }
        }
        public int GetMemberId(int id)
        {

            using (var context = new SnitzDataContext())
            {
                Sql sql = new Sql();
                sql.Select("I_MID");
                sql.From(context.ForumTablePrefix + "IMAGES");
                sql.Where("I_ID=@0", id);
                return context.ExecuteScalar<int>(sql);

            }
        }

        public void Delete(int id)
        {
            using (var context = new SnitzDataContext())
            {
                context.Delete<ImageComment>(id);
            }
        }
    }

}