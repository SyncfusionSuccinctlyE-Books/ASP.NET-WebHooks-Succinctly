using ActivityTracker.Attributes;

namespace ActivityTracker.Enums
{
    public enum EnumRepository
    {
        [EnumDisplayName("Changes pushed to remote")]
        [EnumDisplayCode("repo:push")]
        push,
        [EnumDisplayName("Fork")]
        [EnumDisplayCode("repo:fork")]
        fork,
        [EnumDisplayName("Updated")]
        [EnumDisplayCode("repo:updated")]
        updated,
        [EnumDisplayName("Commit comment created")]
        [EnumDisplayCode("repo:commit_comment_created")]
        commitcommentcreated,
        [EnumDisplayName("Commit status created")]
        [EnumDisplayCode("repo:commit_status_created")]
        commitstatuscreated,
        [EnumDisplayName("Commit status updated")]
        [EnumDisplayCode("repo:commit_status_updated")]
        commitstatusupdated

    }
}
