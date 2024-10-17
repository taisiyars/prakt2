
namespace Lib_3
{
    public class Raschet
    {
        /// <summary>
        /// Расчет разницы эллементов массива
        /// </summary>
        /// <param name="mas">Массив</param>
        /// <returns>Разница элементов массива </returns>
        public static int Differrence(int[] mas)
        {
            int razn = mas[0];
            for (int i = 1; i < mas.Length; i++) razn= razn - mas[i];
            return razn;
        }
    }

}
