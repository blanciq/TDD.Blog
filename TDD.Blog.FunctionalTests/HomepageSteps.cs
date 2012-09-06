using System;
using System.Diagnostics;
using NUnit.Framework;
using TDD.Blog.FunctionalTests.Fixtures;
using TDD.Blog.FunctionalTests.Infrasctructure;
using TDD.Blog.Infrastructure;
using TDD.DbTestHelpers.SpecFlow;
using TechTalk.SpecFlow;
using WatiN.Core;

namespace TDD.Blog.FunctionalTests
{
    [Binding]
    public class HomepageSteps
    {
        [BeforeTestRun]
        public static void InitializeFixture()
        {
            FixtureSteps.FixtureModel = typeof (YamlFixtureModel);
            FixtureSteps.YamlFileName = "posts.yaml";
            FixtureSteps.Context = new BlogDbContext();
        }

        [When(@"user enters homepage")]
        public void EnterHomepage()
        {
            Console.WriteLine("Entering homepage...");
            var url = new Uri("http://localhost/", UriKind.Absolute);
            Settings.WaitForCompleteTimeOut = 300;
            WebBrowser.Current.GoTo(url);
        }

        [Then(@"title of five posts should be displayed")]
        public void FivePostsShouldBeDisplayed()
        {
            Assert.AreEqual(5, WebBrowser.Current.Divs.Filter(Find.ByClass("post")).Count);
        }

        [AfterTestRun]
        public static void After()
        {
            Trace.WriteLine("After");
        }
    }
}
