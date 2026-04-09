using UnityEngine;

public class SimpleMenu : MonoBehaviour
{
    public RectTransform[] options; // 싸운다, 도망간다
    public RectTransform cursor;    // ▶ 커서

    int currentIndex = 0;

    void Start()
    {
        UpdateCursor();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentIndex--;
            if (currentIndex < 0)
                currentIndex = options.Length - 1;

            UpdateCursor();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentIndex++;
            if (currentIndex >= options.Length)
                currentIndex = 0;

            UpdateCursor();
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            Select();
        }
    }

    void UpdateCursor()
    {
        cursor.position = new Vector3(
            cursor.position.x,
            options[currentIndex].position.y,
            cursor.position.z
        );
    }

    void Select()
    {
        if (currentIndex == 0)
        {
            Debug.Log("싸운다 선택");
        }
        else if (currentIndex == 1)
        {
            Debug.Log("도망간다 선택");
        }
    }
}