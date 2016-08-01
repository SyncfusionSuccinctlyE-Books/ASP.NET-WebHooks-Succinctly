namespace BitBucketSampleReceiverApp.Constants
{
    public class BitBucketRepoAction
    {
        //Refer to: https://confluence.atlassian.com/bitbucket/event-payloads-740262817.html#EventPayloads-RepositoryEvents
        public const string Push = "repo:push";
        public const string Fork = "repo:fork";
        public const string Updated = "repo:updated";
        public const string CommitCommentCreated = "repo:commit_comment_created";
        public const string CommitStatusCreated = "repo:commit_status_created";
        public const string CommitStatusUpdated = "repo:commit_status_updated";
    }
}