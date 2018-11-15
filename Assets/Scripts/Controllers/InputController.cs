using UnityEngine;

public class InputController : MonoBehaviour
{
    Contexts _contexts;
    private float _offsetX;
    private float _offsetY;
    private Vector3 _clickPos;
    private float _time;

    void Awake()
    {
        _contexts = Contexts.sharedInstance;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 100);
            if (hit.collider != null)
            {
                _clickPos = hit.collider.transform.position;
                _contexts.input.ReplaceClick((int)_clickPos.x, (int)_clickPos.y);

                _offsetX = 0;
                _offsetY = 0;
                _time = 0;
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (_time < 0)
                return;
            if (_time < 0.5f)
            {
                _time += Time.deltaTime;
                _offsetX += Input.GetAxis("Mouse X");
                _offsetY += Input.GetAxis("Mouse Y");
            }
            else
            {
                Slide();
                _time = -1;
            }
        }

        if (Input.GetMouseButtonUp(0) && _time < 0.5f)
        {
            Slide();
        }

    }

    private void Slide()
    {
        SlideDirection direction = Mathf.Abs(_offsetX) > Mathf.Abs(_offsetY)
                     ? _offsetX > 0 ? SlideDirection.RIGHT : SlideDirection.LEFT
                     : _offsetY > 0 ? SlideDirection.UP : SlideDirection.DOWN;
        _contexts.input.ReplaceSlide(new IntVector2((int)_clickPos.x, (int)_clickPos.y), direction);
    }
}
