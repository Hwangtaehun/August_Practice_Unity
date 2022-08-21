using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    public long money;
    public long moneyIncreaseAmount;
    public long moneyIncreaseLevel;
    public long moneyIncreasePrice;
    public int employee = 1;
    public long employeeIncreaseAmount;
    public long employeePrice;

    public Text textMoney;
    public Text textEmployee;

    public GameObject panelPrice;
    public GameObject panelRecruit;

    public GameObject prefabDesk;
    public GameObject prefabFloor;

    public Vector2[] line;
    public float space;

    public float spaceFloor;
    public int floorCapacity;   //바닥 하나 당 수용 가능 인원
    private float floorNumber = 1;

    private void Awake()
    {
        gm = this;
    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (money != 0)
            textMoney.text = money.ToString("###,###") + " 원";
        else
            textMoney.text = "0 원";

        if (employee != 0)
            textEmployee.text = employee.ToString("###,###") + " 명";
        else
            textEmployee.text = "0 명";

        UpdateUpgradePanel();

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    public void PanelSwitch(GameObject obj)
    {
        obj.SetActive(!obj.activeSelf);
    }

    void UpdateUpgradePanel()
    {

        if (panelPrice.activeSelf == true)
        {
            Text textPrice = panelPrice.transform.Find("Text").GetComponent<Text>();

            textPrice.text = "Lv." + moneyIncreaseLevel + " 단가 상승\n";
            textPrice.text += "외주 당 단가>\n";
            textPrice.text += moneyIncreaseAmount.ToString("###,###") + " 원\n";
            textPrice.text += "업그레이드 가격>\n";
            textPrice.text += moneyIncreasePrice.ToString("###,###") + " 원";
        }
        if (panelRecruit.activeSelf == true)
        {
            Text textRecruit = panelRecruit.transform.Find("Text").GetComponent<Text>();

            textRecruit.text = "Lv." + employee + " 신규 고용\n";
            textRecruit.text += "직원 외주 당 단가>\n";
            textRecruit.text += employeeIncreaseAmount.ToString("###,###") + " 원\n";
            textRecruit.text += "업그레이드 가격>\n";
            textRecruit.text += employeePrice.ToString("###,###") + " 원";
        }
    }

    public void UpgradePrice()
    {
        if(money >= moneyIncreasePrice)
        {
            money -= moneyIncreasePrice;
            moneyIncreaseLevel += 1;
            moneyIncreaseAmount += moneyIncreaseLevel * 100;
            moneyIncreasePrice += moneyIncreaseLevel * 500;
        }
    }

    public void UpgradeRecruit()
    {
        if (money >= employeePrice)
        {
            money -= employeePrice;
            employee += 1;
            employeeIncreaseAmount += moneyIncreaseLevel * 5;
            employeePrice += employee * 500;
            CreateEmployee();
            CreateFloor();
        }
    }

    void CreateEmployee()
    {
        float spotX = line[employee % line.Length].x;
        float spotY = line[employee % line.Length].y + -space * (employee / line.Length);

        GameObject obj = Instantiate(prefabDesk, new Vector2(spotX, spotY), Quaternion.identity);

    }

    void CreateFloor()
    {
        float capacity = (employee + 1) / floorCapacity;
        if (capacity >= floorNumber)
        {
            GameObject obj = Instantiate(prefabFloor, new Vector2(0, -spaceFloor * capacity), Quaternion.identity);
            floorNumber += 1;
            Camera.main.GetComponent<CameraDrag>().limitMinY -= spaceFloor;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        for (int i = 0; i < line.Length; i++)
        {
            Gizmos.DrawSphere(line[i], 0.3f);
        }
    }
}
