using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicaPersonajeNinja : MonoBehaviour {


    public float velMovimiento = 5.0f;
    public float velRotation = 200.0f;
    private Animator anim;
    public float x, y;

    [SerializeField]
    private float _jumpForce = 6f;
    private float _jumping;
    [SerializeField]
    private int _maxjump = 2;
    [SerializeField]
    private int _CurrentJumps;
    [SerializeField]
    private Vector3 _StartPosision;
    private CharacterController _playerController;
    private float _lastJump = 0;

    [SerializeField]
    int _puntaje = 0;
    [SerializeField]
    int _vidas = 3;

    [SerializeField]
    private Button _ResetButton;
    private Reset_Scene_Script _ResetButtonScript;

    [SerializeField]
    private Button _victoria;

    #region interfaz
    [SerializeField]
    private Text _ScoreText;
    [SerializeField]
    private Text _VidasText;
    //[SerializeField]
    //private Text _VictoriText;
    #endregion

    #region boundaries
    private float _YlowBound = -6f;
    #endregion

    private AudioAdmin audio;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        _StartPosision = transform.position;

        _playerController = GetComponent<CharacterController>();
        #region Get Reset Scene Script
        _ResetButtonScript = _ResetButton.GetComponent<Reset_Scene_Script>();
        if (_ResetButtonScript == null)
        {
            Debug.LogError("No se encontró el script del botón");
        }
        #endregion

        audio = GameObject.FindObjectOfType<AudioAdmin>();
        if (audio == null)
        {
            Debug.LogError("No se encontro Audio");
        }

        ShowScore();
    }
	
	// Update is called once per frame
	void Update () {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        //Debug.Log(transform);
        transform.Rotate(0, x * Time.deltaTime * velRotation, 0);
        transform.Translate(0, 0, y * Time.deltaTime * velMovimiento);
        
        Vector3 movement = new Vector3(0, _jumping, 0);
        _playerController.Move(movement * Time.deltaTime);

        anim.SetFloat("velX", x);
        anim.SetFloat("velY", y);

        //jump
        if (_playerController.isGrounded == true)
        {
            _CurrentJumps = 0;
        }
        if (_CurrentJumps < _maxjump)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {

                _jumping += _jumpForce;
                _CurrentJumps++;
                anim.SetTrigger("isJumping");
                _lastJump = Time.time;
                audio.PlayAudio("salto");
            }

        }

        CheckBounds();
    }

    private void FixedUpdate()
    {
        if (Time.time - _lastJump > 0.05)
        {
            if (_playerController.isGrounded == false)
            {
                _jumping += Physics.gravity.y * Time.deltaTime;
            }
            else
            {
                _jumping = 0.0f;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coleccionable"))
        {
            _puntaje += 1;
            other.gameObject.SetActive(false);
            audio.PlayAudio("coin");
            ShowScore();
        }
        if (other.CompareTag("SubMeta"))
        {
            _StartPosision = other.gameObject.transform.position;
            _puntaje += 1;
            other.gameObject.SetActive(false);
            audio.PlayAudio("coin");
            ShowScore();
        }
        if (other.CompareTag("Meta"))
        {
            _StartPosision = other.gameObject.transform.position;
            _puntaje += 5;
            other.gameObject.SetActive(false);
            audio.PlayAudio("coin");
            ShowScore();
            Victoria();
        }
        if (other.CompareTag("Obstaculo"))
        {
            dead();
        }
    }

    private void CheckBounds()
    {
        if (transform.position.y <= _YlowBound)
        {
            dead();
        }

    }

    private void dead()
    {
        _vidas = _vidas - 1;
        transform.position = _StartPosision;
        ShowScore();
        audio.PlayAudio("dead");
        if (_vidas < 1)
        {
            SceneManager.LoadScene("Scene1");
        }
    }

    private void ShowScore()
    {
        _ScoreText.text = "Puntaje: " + _puntaje;
        _VidasText.text = "Vidas: " + _vidas;


        if (_puntaje >= 3)
        {
            float aumento = Mathf.Round(_puntaje / 3);
            _jumpForce = 6f + aumento;
        }

    }

    private void Victoria()
    {
        _ResetButtonScript.ShowButton();
        _victoria.image.gameObject.SetActive(true);
        //_VictoriText.text = "Victoria!!";
    }
}
