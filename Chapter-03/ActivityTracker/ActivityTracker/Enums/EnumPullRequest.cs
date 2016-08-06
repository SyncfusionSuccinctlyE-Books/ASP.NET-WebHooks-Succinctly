using ActivityTracker.Attributes;

namespace ActivityTracker.Enums
{
    public enum EnumPullRequest
    {
        [EnumDisplayName("Pullrequest created")]
        [EnumDisplayCode("pullrequest:created")]
        created,
        [EnumDisplayName("Pullrequest udpated")]
        [EnumDisplayCode("pullrequest:updated")]
        updated,
        [EnumDisplayName("pullrequest approved")]
        [EnumDisplayCode("pullrequest:approved")]
        approved,
        [EnumDisplayName("pullrequest unapproved")]
        [EnumDisplayCode("pullrequest:unapproved")]
        approvalremoved,
        [EnumDisplayName("pullrequest merged")]
        [EnumDisplayCode("pullrequest:fulfilled")]
        merged,
        [EnumDisplayName("pullrequest rejected")]
        [EnumDisplayCode("pullrequest:rejected")]
        declined,
        [EnumDisplayName("pullrequest comment created")]
        [EnumDisplayCode("pull_request:comment_created")]
        commentcreated,
        [EnumDisplayName("pullrequest comment updated")]
        [EnumDisplayCode("pull_request:comment_updated")]
        commentupcated,
        [EnumDisplayName("pullrequest comment deleted")]
        [EnumDisplayCode("pull_request:comment_deleted")]
        commentdeleted
    }
}