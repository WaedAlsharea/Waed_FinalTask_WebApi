using learn.core.Domain;
using learn.core.Reopsitory;
using learn.core.Repository;
using learn.core.Service;
using learn.infra.Domain;
using learn.infra.Repository;
using learn.infra.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Waed_FinalTask_WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddScoped<IDBContext, DBContext>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IFriendshipRepository, FriendshipRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IGroupMsgRepository, GroupMsgRepository>();
            services.AddScoped<ILikeRepository, LikeRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IUserGroupRepository, UserGroupRepository>();
            services.AddScoped<IUserMsgRepository, UserMsgRepository>();
            services.AddScoped<IUserRepository, UserRepository>();


            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IFriendshipService, FriendshipService>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<IGroupMsgService, GroupMsgService>();
            services.AddScoped<ILikeService, LikeService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IServiceService, ServiceService>();
            services.AddScoped<IUserGroupService, UserGroupService>();
            services.AddScoped<IUserMsgService, UserMsgService>();
            services.AddScoped<IUserService, UserService>();




            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
