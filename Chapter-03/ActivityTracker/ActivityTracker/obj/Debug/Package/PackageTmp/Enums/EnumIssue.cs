using ActivityTracker.Attributes;

namespace ActivityTracker.Enums
{
    public enum EnumIssue
    {
        [EnumDisplayName("New issue created")]
        [EnumDisplayCode("issue:created")]
        created,
        [EnumDisplayName("Existing issue udpated")]
        [EnumDisplayCode("issue:updated")]
        updated,
        [EnumDisplayName("Issue comment")]
        [EnumDisplayCode("issue:comment_created")]
        commentcreated
    }
}
