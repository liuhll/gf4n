namespace Kamo.Common.Enums
{
    public enum ActionResultCode
    {
        /// <summary>
        /// 成功
        /// </summary>
        Success = 0,

        /// <summary>
        ///Token超时，需要重新认证
        /// </summary>
        TokenOvertime = 1,

        /// <summary>
        /// 认证失败
        /// </summary>
        Unauthorized = 2,

        /// <summary>
        /// 业务执行失败
        /// </summary>
        BussinessError = 3,

        /// <summary>
        /// 数据输入错误(校验失败)
        /// </summary>
        UnVerification = 4,

        /// <summary>
        /// 未知异常
        /// </summary>
        UnknownError = 5,
    }
}