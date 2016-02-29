using System;

using FluentAssertions;

using Moq;
using Scissorhands.Helpers;
using Scissorhands.Models.Settings;
using Scissorhands.Services.Tests.Fixtures;

using Xunit;

namespace Scissorhands.Services.Tests
{
    /// <summary>
    /// This represents the test entity for the <see cref="ViewModelService"/> class.
    /// </summary>
    public class ViewModelServiceTest : IClassFixture<ViewModelServiceFixture>
    {
        private readonly Mock<ISiteMetadataSettings> _metadata;
        private readonly Mock<IHttpRequestHelper> _httpRequestHelper;
        private readonly Mock<IThemeHelper> _themeHelper;
        private readonly ViewModelService _service;


        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModelServiceTest"/> class.
        /// </summary>
        /// <param name="fixture"><see cref="ViewModelServiceFixture"/> instance.</param>
        public ViewModelServiceTest(ViewModelServiceFixture fixture)
        {
            this._metadata = fixture.SiteMetadataSettings;
            this._httpRequestHelper = fixture.HttpRequestHelper;
            this._themeHelper = fixture.ThemeHelper;
            
            this._service = fixture.ViewModelService;
        }
        
        /// <summary>
        /// Tests whether the constructor should throw an exception or not.
        /// </summary>
        [Fact]
        public void Given_NullParameter_Constructor_ShouldThrow_ArgumentNullException()
        {
            Action action = () => { var service = new ViewModelService(null, this._httpRequestHelper.Object, this._themeHelper.Object); };
            action.ShouldThrow<ArgumentNullException>();
            
            action = () => { var service = new ViewModelService(this._metadata.Object, null, this._themeHelper.Object); };
            action.ShouldThrow<ArgumentNullException>();
            
            action = () => { var service = new ViewModelService(this._metadata.Object, this._httpRequestHelper.Object, null); };
            action.ShouldThrow<ArgumentNullException>();
        }
        
        /// <summary>
        /// Tests whether constructor should NOT throw an exception or not.
        /// </summary>
        [Fact]
        public void Given_Parameters_Constructor_ShouldThrow_NoException()
        {
            Action action = () => { var service = new ViewModelService(this._metadata.Object, this._httpRequestHelper.Object, this._themeHelper.Object); };
            action.ShouldNotThrow<Exception>();
        }
    }
}