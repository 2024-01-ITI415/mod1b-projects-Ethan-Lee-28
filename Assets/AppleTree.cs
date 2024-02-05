using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour {
    [Header("Set in Inspector")]
    public GameObject applePrefab;
    public float speed = 1f;
    public float leftAndRightEdge = 10f;
    public float chanceToChangeDirections = 0.1f;
    public float secondsBetweenAppleDrops = 1f;
    public static float bottomY = -20f;
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;

    private List<GameObject> baskets = new List<GameObject>();

    // Start is called before the first frame update
    void Start() {
        Invoke("DropApple", 2f);

        // Instantiate baskets and store them in a list
        for (int i = 0; i < numBaskets; i++) {
            GameObject tBasketGo = Instantiate(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (i * basketSpacingY);
            tBasketGo.transform.position = pos;

            baskets.Add(tBasketGo);
        }
    }

    void DropApple() {
        GameObject apple = Instantiate(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }

    // Update is called once per frame
    void Update() {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        // Get the mouse position in 3D space
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        // Update the x position of each basket to follow the mouse
        foreach (GameObject basket in baskets) {
            Vector3 basketPos = basket.transform.position;
            basketPos.x = mousePos3D.x;
            basket.transform.position = basketPos;
        }
    }

    void OnCollisionEnter(Collision coll) {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Apple") {
            Destroy(collidedWith);
        }
    }

    // Rest of the code (if any)
    // ...
}
