using Fonlow.ErpNext.Models;
using System.Text.Json.Serialization;

namespace Fonlow.ErpNext.DocTypes
{
    [ErpNextDocType("User")]
    public class UserDT : DocTypeBase
    {
        [JsonPropertyName("owner")]
        public string Owner { get; set; }

        [JsonPropertyName("creation")]
        public DateTime Creation { get; set; }

        [JsonPropertyName("modified")]
        public DateTime Modified { get; set; }

        [JsonPropertyName("modified_by")]
        public string ModifiedBy { get; set; }

        [JsonPropertyName("docstatus")]
        public int DocStatus { get; set; }

        [JsonPropertyName("idx")]
        public int Idx { get; set; }

        [JsonPropertyName("enabled")]
        public int Enabled { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("middle_name")]
        public string MiddleName { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        [JsonPropertyName("full_name")]
        public string FullName { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; }

        [JsonPropertyName("time_zone")]
        public string TimeZone { get; set; }

        [JsonPropertyName("send_welcome_email")]
        public int SendWelcomeEmail { get; set; }

        [JsonPropertyName("unsubscribed")]
        public int Unsubscribed { get; set; }

        [JsonPropertyName("user_image")]
        public string UserImage { get; set; }

        [JsonPropertyName("role_profile_name")]
        public string RoleProfileName { get; set; }

        [JsonPropertyName("module_profile")]
        public string ModuleProfile { get; set; }

        [JsonPropertyName("home_settings")]
        public string HomeSettings { get; set; }

        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("birth_date")]
        public string BirthDate { get; set; }

        [JsonPropertyName("interest")]
        public string Interest { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("location")]
        public string Location { get; set; }

        [JsonPropertyName("bio")]
        public string Bio { get; set; }

        [JsonPropertyName("mobile_no")]
        public string MobileNo { get; set; }

        [JsonPropertyName("mute_sounds")]
        public int MuteSounds { get; set; }

        [JsonPropertyName("desk_theme")]
        public string DeskTheme { get; set; }

        [JsonPropertyName("banner_image")]
        public string BannerImage { get; set; }

        [JsonPropertyName("search_bar")]
        public int SearchBar { get; set; }

        [JsonPropertyName("notifications")]
        public int Notifications { get; set; }

        [JsonPropertyName("list_sidebar")]
        public int ListSidebar { get; set; }

        [JsonPropertyName("bulk_actions")]
        public int BulkActions { get; set; }

        [JsonPropertyName("view_switcher")]
        public int ViewSwitcher { get; set; }

        [JsonPropertyName("form_sidebar")]
        public int FormSidebar { get; set; }

        [JsonPropertyName("timeline")]
        public int Timeline { get; set; }

        [JsonPropertyName("dashboard")]
        public int Dashboard { get; set; }

        [JsonPropertyName("new_password")]
        public string NewPassword { get; set; }

        [JsonPropertyName("logout_all_sessions")]
        public int LogoutAllSessions { get; set; }

        [JsonPropertyName("reset_password_key")]
        public string ResetPasswordKey { get; set; }

        
        [JsonPropertyName("last_reset_password_key_generated_on")]
        public DateTime? LastResetPasswordKeyGeneratedOn { get; set; }

        [JsonPropertyName("last_password_reset_date")]
        public DateOnly? LastPasswordResetDate { get; set; } //modified by Z

        [JsonPropertyName("redirect_url")]
        public string RedirectUrl { get; set; }

        [JsonPropertyName("document_follow_notify")]
        public int DocumentFollowNotify { get; set; }

        [JsonPropertyName("document_follow_frequency")]
        public string DocumentFollowFrequency { get; set; }

        [JsonPropertyName("follow_created_documents")]
        public int FollowCreatedDocuments { get; set; }

        [JsonPropertyName("follow_commented_documents")]
        public int FollowCommentedDocuments { get; set; }

        [JsonPropertyName("follow_liked_documents")]
        public int FollowLikedDocuments { get; set; }

        [JsonPropertyName("follow_assigned_documents")]
        public int FollowAssignedDocuments { get; set; }

        [JsonPropertyName("follow_shared_documents")]
        public int FollowSharedDocuments { get; set; }

        [JsonPropertyName("email_signature")]
        public string EmailSignature { get; set; }

        [JsonPropertyName("thread_notify")]
        public int ThreadNotify { get; set; }

        [JsonPropertyName("send_me_a_copy")]
        public int SendMeACopy { get; set; }

        [JsonPropertyName("allowed_in_mentions")]
        public int AllowedInMentions { get; set; }

        [JsonPropertyName("default_workspace")]
        public string DefaultWorkspace { get; set; }

        [JsonPropertyName("default_app")]
        public string DefaultApp { get; set; }

        [JsonPropertyName("simultaneous_sessions")]
        public int SimultaneousSessions { get; set; }

        [JsonPropertyName("restrict_ip")]
        public string RestrictIp { get; set; }

        [JsonPropertyName("last_ip")]
        public string LastIp { get; set; }

        [JsonPropertyName("login_after")]
        public int LoginAfter { get; set; }

        [JsonPropertyName("user_type")]
        public string UserType { get; set; }

        
        [JsonPropertyName("last_active")]
        public DateTime? LastActive { get; set; }

        [JsonPropertyName("login_before")]
        public int LoginBefore { get; set; }

        [JsonPropertyName("bypass_restrict_ip_check_if_2fa_enabled")]
        public int BypassRestrictIpCheckIf2faEnabled { get; set; }

        
        [JsonPropertyName("last_login")]
        public DateTime? LastLogin { get; set; }

        //[JsonPropertyName("last_known_versions")] not my concern
        //public string LastKnownVersions { get; set; }

        [JsonPropertyName("api_key")]
        public string ApiKey { get; set; }

        [JsonPropertyName("api_secret")]
        public string ApiSecret { get; set; }

        [JsonPropertyName("onboarding_status")]
        public object OnboardingStatus { get; set; }
    }

}
