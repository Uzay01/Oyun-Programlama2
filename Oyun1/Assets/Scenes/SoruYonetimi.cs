using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SimpleSoruYonetimi : MonoBehaviour
{
    public TextMeshProUGUI soruMetniText;
    public InputField cevapInputField;
    public int soruSayisi = 5;
    private int dogruSonuc = -1;
    private int suankiSoruIndex = 0;

    void Start()
    {
        SoruSor();
    }
    void Update()
    {
        // Check for Enter key press
        if (Input.GetKeyDown(KeyCode.Return))
        {
            CevapKontrol();
        }
    }

    void SoruSor()
    {
        if (suankiSoruIndex < soruSayisi)
        {
            int sayi1 = Random.Range(2, 10);
            int sayi2 = Random.Range(2, 10);
            dogruSonuc = sayi1 * sayi2;

            string soruMetni = $"{sayi1} x {sayi2} = ?";

            soruMetniText.text = soruMetni;
        }
        else
        {
            Debug.Log("Sorular bitti!");

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    void CevapKontrol()
    {

        string kullaniciCevabi = cevapInputField.text;
        if (kullaniciCevabi.Length == 0)
        {
            return;
        }

        cevapInputField.text = "";

        if (int.TryParse(kullaniciCevabi, out int kullaniciCevabiInt))
        {
            if (kullaniciCevabiInt == dogruSonuc)
            {
                Debug.Log("Doðru Cevap!");
            }
            else
            {
                Debug.Log($"Yanlýþ Cevap! Doðru Cevap: {dogruSonuc}");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }
        }
        else
        {
            Debug.Log("Geçersiz giriþ. Bir sayý giriniz.");
        }

        // Sonraki soruya geç.
        suankiSoruIndex++;
        SoruSor();
    }
}
