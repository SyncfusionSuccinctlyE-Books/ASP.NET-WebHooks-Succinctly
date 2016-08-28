using ActivityTracker.Attributes;

namespace ActivityTracker.Enums
{
    public enum EnumBitBucketAction
    {
        //Repository
        [EnumDisplayName("Changes pushed to remote")]
        [EnumDisplayCode("repo:push")]
        Push,
        [EnumDisplayName("Fork")]
        [EnumDisplayCode("repo:fork")]
        Fork,
        [EnumDisplayName("Updated")]
        [EnumDisplayCode("repo:updated")]
        Updated,
        [EnumDisplayName("Commit comment created")]
        [EnumDisplayCode("repo:commit_comment_created")]
        Commitcommentcreated,
        [EnumDisplayName("Commit status created")]
        [EnumDisplayCode("repo:commit_status_created")]
        Commitstatuscreated,
        [EnumDisplayName("Commit status updated")]
        [EnumDisplayCode("repo:commit_status_updated")]
        Commitstatusupdated,

        //Pull request
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
        commentdeleted,

        //Issue
        [EnumDisplayName("New issue created")]
        [EnumDisplayCode("issue:created")]
        issuecreated,
        [EnumDisplayName("Existing issue udpated")]
        [EnumDisplayCode("issue:updated")]
        issueupdated,
        [EnumDisplayName("Issue comment")]
        [EnumDisplayCode("issue:comment_created")]
        issuecommentcreated
    }
}