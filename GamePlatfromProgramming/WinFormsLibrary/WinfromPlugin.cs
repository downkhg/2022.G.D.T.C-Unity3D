//1.Windowsforms클래스라이브러리 생성
//2..Net6(장기지원) 선택
//3.Release 빌드 > 탭 > 상위폴더 > "bin/release/.Net6.0/dll"
namespace WinFormsLibrary
{
    public class WinfromPlugin
    {
        static public void MessageBoxShow(string text, string caption)
        {
            MessageBox.Show(text, caption);
        }
    }
}