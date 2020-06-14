using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllClass
{
    /// <summary>
    /// Структра которая нужна только для структуры Info_XElementJobForList
    /// </summary>
    [System.Serializable]
    public struct PropertyXElementJob
    {
        private int Id;
        private string DirInput;
        private string DirOutput;

        public void Set(int xId, string xDirInput, string xDirOutput) { Id = xId; DirInput = xDirInput; DirOutput = xDirOutput; }

        public static bool operator !=(PropertyXElementJob Own, PropertyXElementJob Old)
        {
            bool Rezult = false;

            if (Own._Id != Old._Id || Own._DirInput != Old._DirInput || Own._DirOutput != Old._DirOutput) { Rezult = true; }

            return Rezult;
        }

        public static bool Equals(PropertyXElementJob Own, PropertyXElementJob Old)
        {
            return Own._Id == Old._Id && Own._DirInput == Old._DirInput && Own._DirOutput == Old._DirOutput;
        }

        public static int GetHashCode(PropertyXElementJob Old)
        {
            return (Old._Id, Old._DirInput, Old._DirOutput).GetHashCode();
        }

        public static bool operator ==(PropertyXElementJob Own, PropertyXElementJob Old)
        {
            bool Rezult = false;

            if (Own._Id == Old._Id && Own._DirInput == Old._DirInput && Own._DirOutput == Old._DirOutput) { Rezult = true; }

            return Rezult;
        }

        public PropertyXElementJob Value()
        {
            PropertyXElementJob propertyXElementJobTemp = new PropertyXElementJob();

            propertyXElementJobTemp._Id = Id;
            propertyXElementJobTemp._DirInput = DirInput;
            propertyXElementJobTemp._DirOutput = DirOutput;

            return propertyXElementJobTemp;
        }

        public int _Id
        {
            get { return Id; }
            set { Id = value; }
        }

        public string _DirInput
        {
            get { return DirInput; }
            set { DirInput = value; }
        }

        public string _DirOutput
        {
            get { return DirOutput; }
            set { DirOutput = value; }
        }
    }

    /// <summary>
    /// Структура даных для пользовательского компонента XElementJobForList нужно убрать.
    /// </summary>
    public struct Info_XElementJobForList
    {
        //private int cxCount;

        private int cxId;
        private string cxDirInput;
        private string cxDirOutput;

        /// <summary>
        /// Функции и процедуры для работи с структурой
        /// </summary>
        #region OperationForStruct

        /// <summary>
        /// Получение иль назначение свойства Id
        /// </summary>
        public int Id
        {
            get { return cxId; }
            set { cxId = Id; }
        }

        /// <summary>
        /// Получение иль назначение свойства DirInput
        /// </summary>
        public string DirInput
        {
            get { return cxDirInput; }
            set { cxDirInput = DirInput; }
        }

        /// <summary>
        /// Получение иль назначение свойства DirOutput
        /// </summary>
        public string DirOutput
        {
            get { return cxDirOutput; }
            set { cxDirOutput = DirOutput; }
        }

        /// <summary>
        /// Получение иль назначение свойства всех свойств, через структуру Info_XElementJobForList, 
        /// где есть доступные свойства Id, DirInput, DirOutput
        /// </summary>
        public PropertyXElementJob ListProperty
        {
            get
            {
                PropertyXElementJob txPropertyXElement = new PropertyXElementJob();
                txPropertyXElement._Id = cxId; txPropertyXElement._DirInput = cxDirInput; txPropertyXElement._DirOutput = cxDirOutput;
                return txPropertyXElement;
            }
            set { cxId = ListProperty._Id; cxDirInput = ListProperty._DirInput; cxDirOutput = ListProperty._DirOutput; }
        }

        #endregion

    }
}