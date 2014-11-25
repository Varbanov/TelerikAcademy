using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using System.Web.Http.Cors;

namespace Exam.WebServices
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();


            config.Routes.MapHttpRoute(
                name: "GamesByIdApi",
                routeTemplate: "api/games/{id}",
                defaults: new 
                { 
                    controller = "Games",
                    Action = "GetById",
                }
            );

            config.Routes.MapHttpRoute(
               name: "OldestNotificationApi",
               routeTemplate: "api/notifications/next",
               defaults: new
               {
                   controller = "Notifications",
                   action = "GetOldest"
               }
           );

            config.Routes.MapHttpRoute(
              name: "NotificationsApi",
              routeTemplate: "api/notifications/",
              defaults: new
              {
                  controller = "Notifications",
                  action = "GetNotifications"
              }
          );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
        }
    }
}
