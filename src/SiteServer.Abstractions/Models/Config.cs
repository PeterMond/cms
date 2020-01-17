using System;
using Datory;
using Datory.Annotations;

namespace SiteServer.Abstractions
{
    [DataTable("siteserver_Config")]
    public class Config : Entity
    {
        [DataColumn]
        public string DatabaseVersion { get; set; }

        [DataColumn]
        public DateTime UpdateDate { get; set; }

        [DataColumn(Extend = true, Text = true)]
        private string SystemConfig { get; set; }

        public bool Initialized => Id > 0;

        public bool IsSeparatedApi { get; set; }

        public string SeparatedApiUrl { get; set; }

        public bool IsLogSite { get; set; } = true;

        public bool IsLogAdmin { get; set; } = true;

        public bool IsLogUser { get; set; } = true;

        public bool IsLogError { get; set; } = true;

        /// <summary>
        /// 是否只查看自己添加的内容
        /// 如果是，那么管理员只能查看自己添加的内容
        /// 如果不是，那么管理员可以查看其他管理员的内容，默认false
        /// 注意：超级管理与，站点管理员，审核管理员，此设置无效
        /// add by sessionliang at 20151217
        /// </summary>
        public bool IsViewContentOnlySelf { get; set; }

        // 是否开启时间阈值
        public bool IsTimeThreshold { get; set; }

        public int TimeThreshold { get; set; } = 60;

        /****************管理员设置********************/

        public int AdminUserNameMinLength { get; set; }

        public int AdminPasswordMinLength { get; set; } = 6;

        public PasswordRestriction AdminPasswordRestriction { get; set; } = PasswordRestriction.LetterAndDigit;

        public bool IsAdminLockLogin { get; set; }

        public int AdminLockLoginCount { get; set; } = 3;

        public LockType AdminLockLoginType { get; set; } = LockType.Hours;

        public int AdminLockLoginHours { get; set; } = 3;

        public bool IsAdminEnforcePasswordChange { get; set; }

        public int AdminEnforcePasswordChangeDays { get; set; } = 90;

        public bool IsAdminEnforceLogout { get; set; }

        public int AdminEnforceLogoutMinutes { get; set; } = 960;

        /****************用户设置********************/

        public bool IsUserRegistrationAllowed { get; set; } = true;

        public string UserRegistrationAttributes { get; set; }

        public bool IsUserRegistrationGroup { get; set; }

        public bool IsUserRegistrationChecked { get; set; } = true;

        public bool IsUserUnRegistrationAllowed { get; set; } = true;

        public int UserPasswordMinLength { get; set; } = 6;

        public PasswordRestriction UserPasswordRestriction { get; set; } = PasswordRestriction.LetterAndDigit;

        public int UserRegistrationMinMinutes { get; set; } = 3;

        public bool IsUserLockLogin { get; set; }

        public int UserLockLoginCount { get; set; } = 3;

        public string UserLockLoginType { get; set; } = "Hours";

        public int UserLockLoginHours { get; set; } = 3;

        public string UserDefaultGroupAdminName { get; set; }

        /****************管理后台设置********************/

        public string AdminTitle { get; set; } = "SiteServer CMS";

        public string AdminLogoUrl { get; set; }

        public string AdminWelcomeHtml { get; set; } = @"欢迎使用 SiteServer CMS 管理后台";

        /****************用户中心设置********************/

        public bool IsHomeClosed { get; set; }

        public string HomeTitle { get; set; } = "用户中心";

        public bool IsHomeLogo { get; set; }

        public string HomeLogoUrl { get; set; }

        public string HomeDefaultAvatarUrl { get; set; }

        public bool IsHomeAgreement { get; set; }

        public string HomeAgreementHtml { get; set; } =
            @"阅读并接受<a href=""/agreement.html"" target=""_blank"">《用户协议》</a>";

    }
}
