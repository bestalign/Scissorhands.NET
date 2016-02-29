using System;

using Moq;
using Scissorhands.Helpers;
using Scissorhands.Models.Settings;

namespace Scissorhands.Services.Tests.Fixtures
{
    /// <summary>
    /// This represents the fixture entity for the <see cref="ViewModelService"/> class.
    /// </summary>
    public class ViewModelServiceFixture : IDisposable
    {
        private bool _disposed;
        
        /// <summary>
        /// Gets the <see cref="Mock{ISiteMetadataSettings}"/> instance.
        /// </summary>
        public Mock<ISiteMetadataSettings> SiteMetadataSettings;
        
        /// <summary>
        /// Gets the <see cref="Mock{IHttpRequestHelper}"/> instance.
        /// </summary>
        public Mock<IHttpRequestHelper> HttpRequestHelper;

        /// <summary>
        /// Gets the <see cref="Mock{IThemeHelper}"/> instance.
        /// </summary>
        public Mock<IThemeHelper> ThemeHelper;
        
        /// <summary>
        /// Gets the <see cref="Mock{ViewModelService}"/> instance.
        /// </summary>
        public ViewModelService ViewModelService;


        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModelServiceFixture"/> class.
        /// </summary>
        public ViewModelServiceFixture()
        {
            this.SiteMetadataSettings = new Mock<ISiteMetadataSettings>();
            this.HttpRequestHelper = new Mock<IHttpRequestHelper>();
            this.ThemeHelper = new Mock<IThemeHelper>();
            
            this.ViewModelService = new ViewModelService(this.SiteMetadataSettings.Object, this.HttpRequestHelper.Object, this.ThemeHelper.Object);
        }
        
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (this._disposed)
            {
                return;
            }

            this.ViewModelService.Dispose();

            this._disposed = true;
        }
    }
}