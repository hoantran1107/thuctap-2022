using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MiddleWare.Controllers
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ContentComponent
    {
        private RequestDelegate nextComponent;
        //phuong thuc khoi tao co tham so bat buoc la RequestDelegate
        public ContentComponent(RequestDelegate nextMiddleware) => nextComponent = nextMiddleware;
        //phuong thuc tra ve 1 Task co tham so truyen vao la HttpContext
        public async Task Invoke(HttpContext httpContext)
        {
            //neu khong goi cac nextComponet co nghia la chi chay qua 1 middleware 
            //se duoc goi la terminal middleware
            bool isTest = Convert.ToBoolean(httpContext.Request.Query["isTest"]);
            if (isTest == true)
            {
                await httpContext.Response.WriteAsync("Day la test ve MiddleWare");
            }
            // chuyen toi middleware phia sau neu co
            else
                await nextComponent(httpContext);
        }
    }
}
