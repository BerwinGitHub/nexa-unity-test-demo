using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MixerManager : MonoBehaviour
{
    Vector3 mixerOldPos;
    public Renderer _renderer;
    public float time = 0f;
    public Slider slider;
    public GameObject GameOverPanel;
    float slidervalue;
    public float i;
    bool isEnd;
    void Start()
    {
        slidervalue = slider.value;
        mixerOldPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnd) return;
        StartPlay();
    }
    void StartPlay()
    {
        
        if (UnityEngine.Input.GetMouseButton(0))
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);//定义射线,以鼠标的位置为终点
            Debug.DrawLine(mouseRay.origin, mouseRay.direction * 10.0f, Color.red);//描绘射线，只在Scene视图中看得见
            RaycastHit hitInfo;
            if (Physics.Raycast(mouseRay, out hitInfo, float.MaxValue)) //进行射线检测，layerMask是检测层级
            {
                GameManager.getinstance().IsPromp = false;
                this.transform.position = new Vector3(hitInfo.point.x, hitInfo.point.y - 0.02f, transform.position.z);
            }
        }
        else
        {
            Reset();
            GameManager.getinstance().IsPromp = true;
        }
    }
    private void Reset()
    {
        if (Vector3.Distance(transform.position, mixerOldPos) > 0.001f)
        {
            transform.position = Vector3.Lerp(transform.position, mixerOldPos, 0.5f);
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if(other.name == "bowl")
        {
            time += Time.deltaTime;
            slider.value += i;
            if (time >= 4f)
            {
                slider.value = 1f;
                GameOverPanel.SetActive(true);
                isEnd = true;
                Reset();
            }
            GameManager.getinstance().IsMix = true;
            _renderer.material.mainTextureOffset = new Vector2(Time.time / 5, Time.time / 5);
        }    
        
    }
    private void OnTriggerExit(Collider other)
    {
        time = 0f;
        slider.value = slidervalue;
        GameManager.getinstance().IsMix = false;
    }
}
