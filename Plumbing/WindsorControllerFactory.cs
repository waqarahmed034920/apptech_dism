using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Microsoft.AspNet.Identity.EntityFramework;
using SurveyPortal.Infrastructure;
using SurveyPortal.Infrastructure.Interface;
using SurveyPortal.Infrastructure.Repositories;
using SurveyPortal.Models;
using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace SurveyPortal.Plumbing
{
    public class WindsorControllerFactory : DefaultControllerFactory
    {
        readonly IWindsorContainer container;

        public WindsorControllerFactory(IWindsorContainer container)
        {
            this.container = container;
            this.container.Register(Component.For<IdentityDbContext<ApplicationUser>>().ImplementedBy<ApplicationDbContext>());
            this.container.Register(Component.For<ICompetition>().ImplementedBy<CompetitionRepository>());
            this.container.Register(Component.For<IFAQRepository>().ImplementedBy<FAQRepository>());
            this.container.Register(Component.For<ISupportInfoRepository>().ImplementedBy<SupportInfoRepository>());
            this.container.Register(Component.For<ISurveyQuestion>().ImplementedBy<SurveyQuestionRepository>());
            this.container.Register(Component.For<ISurveyRepository>().ImplementedBy<SurveyRepository>());
            this.container.Register(Component.For<ISurveyResponseRepository>().ImplementedBy<SurveyResponseRepository>());
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {            
			if (controllerType != null && container.Kernel.HasComponent(controllerType))
				return (IController)container.Resolve(controllerType);

			return base.GetControllerInstance(requestContext, controllerType);
        }

        public override void ReleaseController(IController controller)
        {
            container.Release(controller);
        }
    }
}