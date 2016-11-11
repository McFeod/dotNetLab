using System;

namespace CinemaLibrary.Artifacts
{
    /// <summary>
    /// Сценарий фильма
    /// </summary>
    [Serializable]
    public class Scenario: Artifact
    {
        /// <summary>
        /// Событие, вызываемое при изменении числа страниц сценария
        /// </summary>
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