using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AstrolabeUIBehaviour : MonoBehaviour
{
    public float length;
    private float _Length;
    public float cooldown;
    private float _Cooldown;
    private Image _Image;

    private bool _AstrolabeActivated = false;
    private bool _AstrolabeOnCooldown = false;

	// Use this for initialization
	void Start ()
    {
        _Length = length;
        _Cooldown = cooldown;
        _Image = this.GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (_AstrolabeActivated)
        {
            length -= Time.deltaTime;
            if (length <= 0)
            {
                StopAstrolabe();
                length = 0;
            }
            _Image.fillAmount = length / _Length;
        }

        if (_AstrolabeOnCooldown)
        {
            length += Time.deltaTime;
            if (length >= 15)
            {
                ResetBools();
                length = 15;
            }
            _Image.fillAmount = length / _Length;
        }
	}

    public void StartAstrolabe()
    {
        _Image.gameObject.SetActive(true);
        _AstrolabeActivated = true;
    }

    public void StopAstrolabe()
    {
        _AstrolabeActivated = false;
        _AstrolabeOnCooldown = true;
    }

    public void ResetBools()
    {
        _AstrolabeActivated = false;
        _AstrolabeOnCooldown = false;
    }
}
