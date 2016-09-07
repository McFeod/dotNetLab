namespace LabOneCinema.Artifacts
{
    /// <summary>
    /// Сценарий фильма
    /// </summary>
    public class Scenario: Artifact
    {
        /// <summary>
        /// Число страниц сценария
        /// </summary>
        public ushort PageCount { get; set; }
    }
}