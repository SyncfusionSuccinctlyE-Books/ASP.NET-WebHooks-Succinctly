using ActivityTracker.Attributes;

namespace ActivityTracker.Enums
{
    public enum EnumRepository
    {
        [EnumDisplayName("Changes pushed to remote")] [EnumDisplayCode("repo:push")] Push,
        [EnumDisplayName("Fork")] [EnumDisplayCode("repo:fork")] Fork,
        [EnumDisplayName("Updated")] [EnumDisplayCode("repo:updated")] Updated,
        [EnumDisplayName("Commit comment created")] [EnumDisplayCode("repo:commit_comment_created")] Commitcommentcreated,
        [EnumDisplayName("Commit status created")] [EnumDisplayCode("repo:commit_status_created")] Commitstatuscreated,
        [EnumDisplayName("Commit status updated")] [EnumDisplayCode("repo:commit_status_updated")] Commitstatusupdated
    }
}