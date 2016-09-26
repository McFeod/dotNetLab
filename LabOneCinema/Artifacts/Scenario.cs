using System;

namespace LabOneCinema.Artifacts
{
    /// <summary>
    /// Сценарий фильма
    /// </summary>
    public class Scenario: Artifact
    {
        public event EventHandler OnGrow = (sender, pseudoArgs) => {};
        /// <summary>
        /// Число страниц сценария
        /// </summary>
        private ushort _pageCount;
        public ushort PageCount {
            get { return _pageCount; }
            set
            {
                _pageCount = value;
                OnGrow(this, PseudoArgs);
            }
        }
    }
}