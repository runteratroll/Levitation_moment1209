/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using CodeMonkey.Utils;

public class DamagePopup : MonoBehaviour {

    // Create a Damage Popup
    public static DamagePopup Create(Vector3 position, int damageAmount, bool isCriticalHit, bool isPlayer = false) {

        position = new Vector3(position.x , Random.Range(position.y -3, position.y + 3f), position.z);
        Transform damagePopupTransform = Instantiate(GameAssets.i.pfDamagePopup, position, Quaternion.identity);

        DamagePopup damagePopup = damagePopupTransform.GetComponent<DamagePopup>();
        damagePopup.Setup(damageAmount, isCriticalHit , isPlayer);

        return damagePopup;
    }

    private static int sortingOrder;

    private const float DISAPPEAR_TIMER_MAX = 1f;

    private TextMeshPro textMesh;
    private float disappearTimer;
    private Color textColor;
    private Vector3 moveVector;

    private void Awake() {
        textMesh = transform.GetComponent<TextMeshPro>();
    }



    public void Setup(int damageAmount, bool isCriticalHit, bool isPlayer = false) {
        textMesh.SetText(damageAmount.ToString());


        
        if (!isCriticalHit) {
            // Normal hit

            if(isPlayer)
            {
                textMesh.fontSize = 1f;

                textColor = UtilsClass.GetColorFromString("FFC500");
            }
            else
            {
                textMesh.fontSize = 18;

                textColor = UtilsClass.GetColorFromString("FFC500");
            }

          
        } else {
            // Critical hit
            textMesh.fontSize = 35;
            textColor = UtilsClass.GetColorFromString("FF2B00");
        }
        textMesh.color = textColor;
        disappearTimer = DISAPPEAR_TIMER_MAX;

        sortingOrder++;
        textMesh.sortingOrder = sortingOrder;

        //Vector3 vectorSet = new Vector3(Random.Range) 

        moveVector = new Vector3(1f, Random.Range(0.5f, 2f)) * 15f;
    }

    private void Update() {
        transform.position += moveVector * Time.deltaTime;
        moveVector -= moveVector * 8f * Time.deltaTime;

        if (disappearTimer > DISAPPEAR_TIMER_MAX * .5f)
        {
            // First half of the popup lifetime
            float increaseScaleAmount = 1f;
            transform.localScale += Vector3.one * increaseScaleAmount * Time.deltaTime;
        }
        else
        {
            // Second half of the popup lifetime
            float decreaseScaleAmount = 1f;
            transform.localScale -= Vector3.one * decreaseScaleAmount * Time.deltaTime;
        }

        disappearTimer -= Time.deltaTime;
        if (disappearTimer < 0) {
            // Start disappearing
            float disappearSpeed = 3f;
            textColor.a -= disappearSpeed * Time.deltaTime;
            textMesh.color = textColor;
            if (textColor.a < 0) {
                Destroy(gameObject);
            }
        }
    }

}
