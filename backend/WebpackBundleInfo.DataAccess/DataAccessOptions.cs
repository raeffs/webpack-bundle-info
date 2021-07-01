namespace WebpackBundleInfo
{
    public record DataAccessOptions
    {
        /// <summary>
        /// Whether the database should be recreated on startup.
        /// If true, the database is deleted on startup and recreated with its initial state.
        /// </summary>
        public bool RecreateDatabaseOnStartup { get; init; } = false;

        /// <summary>
        /// Whether the database should be deleted if migrations cannot be applied.
        /// </summary>
        public bool DeleteDatabaseOnMigrationFailure { get; init; } = false;
    }
}
