using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MultiLanguageTutorialScene : MonoBehaviour {
	public Text Text1;
	public Text Text2;
	public Text Text3;
	public Text Text4;
	public Text Text5;
	public Text Text6;
	public Text Text7;
	public Text Text8;
	public Text Text9;
	public Text Text10;
	public Text Text11;
	public Text Text12;
	public Text Text13;
	public Text Text14;
	public Text Text15;
	public Text Text16;
	public Text Text17;
	public Text Text18;
	public Text Text19;
	public Text Text20;

	// Use this for initialization
	void Start () {
			if (Application.systemLanguage.ToString () == "Turkish") {
			Text1.text = "Fren yapmak için fren pedalını kullanın";
			Text2.text = "Yeteneklerİ kullanmak için yetenek butonunu kullanın";
			Text3.text = "Hızlanmak için gaz pedalını kullanın";
			Text4.text = "Yakıt göstergesİ kalan yakıt mİktarını gösterir";
			Text5.text = "Can göstergesİ kalan can mİktarını gösterİr";
			Text6.text = "Can veya yakıt göstergenİz sıfırı gösterİr ise aracınız patlar";
			Text7.text = "Bu bir kapan ve ona çarpmamaya çalışın yoksa aracınız patlar";
			Text8.text = "Bunlar düşmanlarınız ve sizi mayın kullanarak yoketmeye programlanmışlardır." +
				"\tOnlar sİzİ yoketmeden sİz onları yokedİn"; 
			Text9.text = "Bu bİr yakıt bİdonudur ve alırsanız sizin yakıt sevİyenİzİ arttırır";
			Text10.text = "Bu bİr rampa ve üstünden geçerseniz sizi zıplatır";
			Text11.text = "Bu bİr yetenek kutusu ve onu alırsanız özel yetenekler kazanırsınız";
			Text12.text = "Bu yetenek göstergesİdİr";
			Text13.text = "Motor göstergesi";
			Text14.text = "Yakıt göstergesİ";
			Text15.text = "Fren göstergesİ";
			Text16.text = "Hepsini öldür göstergesİ";
			Text17.text = "Yanındakini öldür göstergesİ";
			Text18.text = "Bomba göstergesİ";
			Text19.text = "Can göstergesİ";
			Text20.text = "Nasıl Oynarım";

		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
