using System;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SocialPointTest.Ranking.Application.TDD
{
    public abstract class TestBase<T> where T : class
    {
        protected T service;

        protected AutoMock moqer;

        public void Init()
        {
            this.service = this.CreateService();
        }

        protected virtual T CreateService()
        {
            return this.moqer.Create<T>();
        }

        protected Moq.Mock<TDependency> Mock<TDependency>() where TDependency : class
        {
            return this.moqer.Mock<TDependency>();
        }

    }


}