namespace InfiniteAmmo
{
    using System.ComponentModel;

    using Exiled.API.Interfaces;

    /// <summary>
    /// 插件配置.
    /// </summary>
    public class Config : IConfig
    {
        /// <inheritdoc/>
        [Description("插件总开关.")]
        public bool IsEnabled { get; set; } = true;

        /// <inheritdoc/>
        [Description("调试日志开关.")]
        public bool Debug { get; set; } = false;
    }
}
