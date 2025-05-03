using UnityEngine;

public class EmployeeCardManager : MonoBehaviour
{
    public GameObject employeeCard;  // الكارت اللي هيتعرض
    public float showDistance = 5f;  // المسافة اللي لما اللاعب يقربها يظهر الكارت

    private void Start()
    {
        // في البداية الكارت مش هيظهر
        employeeCard.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        // لما اللاعب يقترب من الموظف (يتم تفعيل التريجر)
        if (other.CompareTag("Player"))
        {
            ShowCard();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // لما اللاعب يبتعد عن الموظف
        if (other.CompareTag("Player"))
        {
            HideCard();
        }
    }

    void ShowCard()
    {
        employeeCard.SetActive(true);  // يظهر الكارت
    }

    void HideCard()
    {
        employeeCard.SetActive(false);  // يختفي الكارت
    }
}
