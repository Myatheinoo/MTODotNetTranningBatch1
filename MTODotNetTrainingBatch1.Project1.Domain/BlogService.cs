using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MTODotNetTrainingBatch1.Project1.Database.Models;

namespace MTODotNetTrainingBatch1.Project1.Domain
{
    public class BlogService
    {
        private readonly AppDbContext _appDbContext;

        public BlogService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public ResponseModel GetAllBlog()
        {
            try
            {
                var list = _appDbContext.TblBlogs.ToList();
                return new ResponseModel(true, "Successful", list);
            }
            catch(Exception ex)
            {
                return new ResponseModel(false, ex.Message);
            } 
        }
        public ResponseModel GetBlogWithPagination(int page, int pageSize)
        {
            try
            {
                var list = _appDbContext.TblBlogs
                                    .Skip((page - 1) * pageSize)
                                    .Take(pageSize)
                                    .ToList();
                return new ResponseModel(true,"Successful",list);
            }
            catch(Exception ex)
            {
                return new ResponseModel(false,ex.Message);
            }
            
        }
        public ResponseModel GetByEachBlog(int blogId)
        {
            try
            {
                var item = _appDbContext.TblBlogs.FirstOrDefault(x => x.BlogId == blogId);
                return new ResponseModel(true, "Successful.", item);
            }
            catch (Exception ex)
            {
                return new ResponseModel(false, ex.Message);
            }
        } 
        public ResponseModel CreateBlog(TblBlog blog)
        {
            try
            {
                _appDbContext.TblBlogs.Add(blog);
                _appDbContext.SaveChanges();
                return new ResponseModel(true, "Successful created.",blog);
            }
            catch (Exception ex)
            {
                return new ResponseModel(false, ex.Message);
            }
        }
    }
}
