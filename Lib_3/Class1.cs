
namespace Lib_3
{
    public class Raschet
    {
        /// <summary>
        /// ������ ������� ���������� �������
        /// </summary>
        /// <param name="mas">������</param>
        /// <returns>������� ��������� ������� </returns>
        public static int Differrence(int[] mas)
        {
            int razn = mas[0];
            for (int i = 1; i < mas.Length; i++) razn= razn - mas[i];
            return razn;
        }
    }

}
