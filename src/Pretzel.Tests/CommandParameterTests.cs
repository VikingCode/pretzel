﻿using NDesk.Options;
using NSubstitute;
using Pretzel.Logic.Commands;
using Pretzel.Logic.Extensibility;
using Pretzel.Logic.Templating;
using Pretzel.Logic.Templating.Context;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace Pretzel.Tests
{
    public class CommandParameterTests
    {
        readonly CommandParameters subject;
        const string ExpectedPath = @"D:\Code";
        const string ExpectedImportFile = @"D:\Code\import.xml";
        const string ExpectedImportType = "wordpress";
        const string ExpectedTemplate = @"jekyll";
        const string ExpectedPort = "8000";
        const decimal ExpectedPortDecimal = 8000;

        public CommandParameterTests()
        {
            subject = new CommandParameters(Enumerable.Empty<IHaveCommandLineArgs>());
        }

        [Fact]
        public void Parse_WhenNoParametersSet_MapsPathToCurrentDirectory()
        {
            var args = new List<string>();
            subject.Parse(args);
            Assert.Equal(Directory.GetCurrentDirectory(), subject.Path);
        }

        [Fact]
        public void Parse_WhenOneParameterSet_MapsToPath()
        {
            var args = new List<string> { ExpectedPath };
            subject.Parse(args);
            Assert.Equal(ExpectedPath, subject.Path);
        }

        [Fact]
        public void Parse_WhenSpecifyingTemplateUsingShortParameter_MapsToPath()
        {
            var args = new List<string> { "--t", ExpectedTemplate };
            subject.Parse(args);
            Assert.Equal(ExpectedTemplate, subject.Template);
        }

        [Fact]
        public void Parse_WhenSpecifyingTemplateUsingFullParameter_MapsToPath()
        {
            var args = new List<string> { "--template", ExpectedTemplate };
            subject.Parse(args);
            Assert.Equal(ExpectedTemplate, subject.Template);
        }

        [Fact]
        public void Parse_WhenSpecifyingTemplateUsingShortParameterSingleDash_MapsToPath()
        {
            var args = new List<string> { "-t", ExpectedTemplate };
            subject.Parse(args);
            Assert.Equal(ExpectedTemplate, subject.Template);
        }

        [Fact]
        public void Parse_WhenSpecifyingTemplateUsingFullParameterSingleDash_MapsToPath()
        {
            var args = new List<string> { "-template", ExpectedTemplate };
            subject.Parse(args);
            Assert.Equal(ExpectedTemplate, subject.Template);
        }

        [Fact]
        public void Parse_WhenSpecifyingPathUsingShortParameter_MapsToPath()
        {
            var args = new List<string> { "--d", ExpectedPath };
            subject.Parse(args);
            Assert.Equal(ExpectedPath, subject.Path);
        }

        [Fact]
        public void Parse_WhenSpecifyingPathUsingFullParameter_MapsToPath()
        {
            var args = new List<string> { "--directory", ExpectedPath };
            subject.Parse(args);
            Assert.Equal(ExpectedPath, subject.Path);
        }

        [Fact]
        public void Parse_WhenSpecifyingPathUsingShortParameterSingleDash_MapsToPath()
        {
            var args = new List<string> { "-d", ExpectedPath };
            subject.Parse(args);
            Assert.Equal(ExpectedPath, subject.Path);
        }

        [Fact]
        public void Parse_WhenSpecifyingPathUsingFullParameterSingleDash_MapsToPath()
        {
            var args = new List<string> { "-directory", ExpectedPath };
            subject.Parse(args);
            Assert.Equal(ExpectedPath, subject.Path);
        }

        [Fact]
        public void Parse_WhenSpecifyingPortWithoutParamerers_IsGreaterThanZero()
        {
            Assert.True(subject.Port > 0);
        }

        [Fact]
        public void Parse_WhenSpecifyingPortUsingShortParameter_MapsToPath()
        {
            var args = new List<string> { "--p", ExpectedPort };
            subject.Parse(args);
            Assert.Equal(ExpectedPortDecimal, subject.Port);
        }

        [Fact]
        public void Parse_WhenSpecifyingPortUsingFullParameter_MapsToPath()
        {
            var args = new List<string> { "--port", ExpectedPort };
            subject.Parse(args);
            Assert.Equal(ExpectedPortDecimal, subject.Port);
        }

        [Fact]
        public void Parse_WhenSpecifyingPortUsingShortParameterSingleDash_MapsToPath()
        {
            var args = new List<string> { "-p", ExpectedPort };
            subject.Parse(args);
            Assert.Equal(ExpectedPortDecimal, subject.Port);
        }

        [Fact]
        public void Parse_WhenSpecifyingPortUsingFullParameterSingleDash_MapsToPath()
        {
            var args = new List<string> { "-port", ExpectedPort };
            subject.Parse(args);
            Assert.Equal(ExpectedPortDecimal, subject.Port);
        }

        [Fact]
        public void Parse_WhenSpecifyingImportFileUsingShortParameter_MapsToPath()
        {
            var args = new List<string> { "--f", ExpectedImportFile };
            subject.Parse(args);
            Assert.Equal(ExpectedImportFile, subject.ImportPath);
        }

        [Fact]
        public void Parse_WhenSpecifyingImportFileUsingFullParameter_MapsToPath()
        {
            var args = new List<string> { "--file", ExpectedImportFile };
            subject.Parse(args);
            Assert.Equal(ExpectedImportFile, subject.ImportPath);
        }

        [Fact]
        public void Parse_WhenSpecifyingImportFileUsingShortParameterSingleDash_MapsToPath()
        {
            var args = new List<string> { "-f", ExpectedImportFile };
            subject.Parse(args);
            Assert.Equal(ExpectedImportFile, subject.ImportPath);
        }

        [Fact]
        public void Parse_WhenSpecifyingImportFileUsingFullParameterSingleDash_MapsToPath()
        {
            var args = new List<string> { "-file", ExpectedImportFile };
            subject.Parse(args);
            Assert.Equal(ExpectedImportFile, subject.ImportPath);
        }

        [Fact]
        public void Parse_WhenSpecifyingImportTypeUsingShortParameter_MapsToPath()
        {
            var args = new List<string> { "--i", ExpectedImportType };
            subject.Parse(args);
            Assert.Equal(ExpectedImportType, subject.ImportType);
        }

        [Fact]
        public void Parse_WhenSpecifyingImportTypeUsingFullParameter_MapsToPath()
        {
            var args = new List<string> { "--import", ExpectedImportType };
            subject.Parse(args);
            Assert.Equal(ExpectedImportType, subject.ImportType);
        }

        [Fact]
        public void Parse_WhenSpecifyingImportTypeUsingShortParameterSingleDash_MapsToPath()
        {
            var args = new List<string> { "-i", ExpectedImportType };
            subject.Parse(args);
            Assert.Equal(ExpectedImportType, subject.ImportType);
        }

        [Fact]
        public void Parse_WhenSpecifyingImportTypeUsingFullParameterSingleDash_MapsToPath()
        {
            var args = new List<string> { "-import", ExpectedImportType };
            subject.Parse(args);
            Assert.Equal(ExpectedImportType, subject.ImportType);
        }

        [Fact]
        public void LaunchBrowser_WhenSpecifyingEmptyList_IsTrue()
        {
            var args = new List<string>();
            subject.Parse(args);
            Assert.True(subject.LaunchBrowser);
        }

        [Fact]
        public void LaunchBrowser_WhenSpecifyingNoBrowserDoubleDash_IsFalse()
        {
            var args = new List<string> { "--nobrowser" };
            subject.Parse(args);
            Assert.False(subject.LaunchBrowser);
        }

        [Fact]
        public void LaunchBrowser_WhenSpecifyingNoBrowserSingleDash_IsFalse()
        {
            var args = new List<string> { "-nobrowser" };
            subject.Parse(args);
            Assert.False(subject.LaunchBrowser);
        }

        [Fact]
        public void IncludeDrafts_WhenSpecifyingEmptyList_IsFalse()
        {
            var args = new List<string>();
            subject.Parse(args);
            Assert.False(subject.IncludeDrafts);
        }

        [Fact]
        public void IncludeDrafts_WhenSpecifyingDraftsDoubleDash_IsTrue()
        {
            var args = new List<string> { "--drafts" };
            subject.Parse(args);
            Assert.True(subject.IncludeDrafts);
        }

        [Fact]
        public void IncludeDrafts_WhenSpecifyingDraftsSingleDash_IsTrue()
        {
            var args = new List<string> { "-drafts" };
            subject.Parse(args);
            Assert.True(subject.IncludeDrafts);
        }

        [Fact]
        public void LaunchBrowser_WhenSpecifyingCleanTargetDoubleDash_IsTrue()
        {
            var args = new List<string> { "--cleantarget" };
            subject.Parse(args);
            Assert.True(subject.CleanTarget);
        }

        [Fact]
        public void LaunchBrowser_WhenSpecifyingCleanTargetSingleDash_IsTrue()
        {
            var args = new List<string> { "-cleantarget" };
            subject.Parse(args);
            Assert.True(subject.CleanTarget);
        }

        [Fact]
        public void LaunchBrowser_WhenNotSpecifyingCleanTarget_IsFalse()
        {
            var args = new List<string>();
            subject.Parse(args);
            Assert.False(subject.CleanTarget);
        }

        [Fact]
        public void CommandParameters_WhenSpecifyingAllParameters_ResultIsCorrect()
        {
            var args = new List<string> { "-template=jekyll", @"-directory=c:\mysite", "-port=8182", "-import=blogger", "-file=BloggerExport.xml", "-drafts", "-nobrowser", "-withproject", "-wiki", "-cleantarget" };

            subject.Parse(args);

            Assert.Equal("jekyll", subject.Template);
            Assert.Equal(@"c:\mysite", subject.Path);
            Assert.Equal(8182, subject.Port);
            Assert.Equal("blogger", subject.ImportType);
            Assert.Equal("BloggerExport.xml", subject.ImportPath);
            Assert.True(subject.IncludeDrafts);
            Assert.False(subject.LaunchBrowser);
            Assert.True(subject.WithProject);
            Assert.True(subject.Wiki);
            Assert.True(subject.CleanTarget);
        }

        [Fact]
        public void CommandParameters_WhenSpecifyingNoParameters_DefaultVeluesResultIsCorrect()
        {
            var args = new List<string>();

            subject.Parse(args);

            Assert.Equal(8080, subject.Port);
            Assert.True(subject.LaunchBrowser);
            Assert.Null(subject.Template);
            Assert.Equal(Directory.GetCurrentDirectory(), subject.Path);
            Assert.Null(subject.ImportType);
            Assert.Null(subject.ImportPath);
            Assert.False(subject.IncludeDrafts);
            Assert.False(subject.WithProject);
            Assert.False(subject.Wiki);
            Assert.False(subject.CleanTarget);
        }

        [Fact]
        public void CommandParameters_WhenSpecifyingCommandExtension_ExtensionParameterIsParsed()
        {
            var extension = Substitute.For<IHaveCommandLineArgs>();
            extension.When(e => e.UpdateOptions(Arg.Any<OptionSet>()))
                .Do(c =>
                {
                    var options = c.Arg<OptionSet>();

                    options.Add<string>("newOption=", "description", v => NewOption = v);
                });

            var subject = new CommandParameters(new List<IHaveCommandLineArgs> { extension });
            var args = new List<string> { "-newOption=test" };

            subject.Parse(args);

            Assert.Equal("test", NewOption);
        }

        protected string NewOption { get; set; }

        [Fact]
        public void Parse_WhenOneParameterSet_MapsToPath_RelativePath()
        {
            var args = new List<string> { "mySite" };

            subject.Parse(args);

            Assert.Equal(Path.Combine(Directory.GetCurrentDirectory(), "mySite"), subject.Path);
        }

        [Fact]
        public void DetectFromDirectory_WhenSpecifyingNoSiteEngines_DefaultValueIsLiquid()
        {
            var siteContext = new SiteContext();

            subject.DetectFromDirectory(new Dictionary<string, ISiteEngine>(), siteContext);

            Assert.Equal("liquid", subject.Template);
        }

        [Fact]
        public void DetectFromDirectory_WhenSpecifyingTwoSiteEngines_CorrectValueIsPicked()
        {
            var siteContext = new SiteContext { Config = new Dictionary<string, object> { { "pretzel", new Dictionary<string, object> { { "engine", "engine2" } } } } };

            var siteEngine1 = Substitute.For<ISiteEngine>();
            siteEngine1.CanProcess(Arg.Any<SiteContext>())
                .Returns(ci => ci.Arg<SiteContext>().Engine == "engine1");

            var siteEngine2 = Substitute.For<ISiteEngine>();
            siteEngine2.CanProcess(Arg.Any<SiteContext>())
                .Returns(ci => ci.Arg<SiteContext>().Engine == "engine2");

            var siteEngines = new Dictionary<string, ISiteEngine> 
            {
                { "engine1", siteEngine1 },
                { "engine2", siteEngine2 },
            };

            subject.DetectFromDirectory(siteEngines, siteContext);

            Assert.Equal("engine2", subject.Template);
        }

        [Fact]
        public void DetectFromDirectory_WhenSpecifyingNoPretzelConfig_DefaultValueIsLiquid()
        {
            var siteContext = new SiteContext { Config = new Dictionary<string, object> { } };

            var siteEngine1 = Substitute.For<ISiteEngine>();
            siteEngine1.CanProcess(Arg.Any<SiteContext>())
                .Returns(ci => ci.Arg<SiteContext>().Engine == "engine1");

            var siteEngines = new Dictionary<string, ISiteEngine> 
            {
                { "engine1", siteEngine1 }
            };

            subject.DetectFromDirectory(siteEngines, siteContext);

            Assert.Equal("liquid", subject.Template);
        }

        [Fact]
        public void DetectFromDirectory_WhenSpecifyingNoEnginInPretzelConfig_DefaultValueIsLiquid()
        {
            var siteContext = new SiteContext { Config = new Dictionary<string, object> { { "pretzel", new Dictionary<string, object> { } } } };

            var siteEngine1 = Substitute.For<ISiteEngine>();
            siteEngine1.CanProcess(Arg.Any<SiteContext>())
                .Returns(ci => ci.Arg<SiteContext>().Engine == "engine1");

            var siteEngines = new Dictionary<string, ISiteEngine> 
            {
                { "engine1", siteEngine1 }
            };

            subject.DetectFromDirectory(siteEngines, siteContext);

            Assert.Equal("liquid", subject.Template);
        }

        [Fact]
        public void DetectFromDirectory_WhenSpecifyingPretzelConfigSimpleValue_DefaultValueIsLiquid()
        {
            var siteContext = new SiteContext { Config = new Dictionary<string, object> { { "pretzel", 42 } } };

            var siteEngine1 = Substitute.For<ISiteEngine>();
            siteEngine1.CanProcess(Arg.Any<SiteContext>())
                .Returns(ci => ci.Arg<SiteContext>().Engine == "engine1");

            var siteEngines = new Dictionary<string, ISiteEngine> 
            {
                { "engine1", siteEngine1 }
            };

            subject.DetectFromDirectory(siteEngines, siteContext);

            Assert.Equal("liquid", subject.Template);
        }
    }
}
