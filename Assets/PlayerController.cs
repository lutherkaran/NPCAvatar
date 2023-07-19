using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Vector3 RandomLocation = Vector3.zero;
    [SerializeField] Vector3 direction = Vector3.zero;
    [SerializeField] float speed;
    const string IS_WALKING = "Walking";

    Animator animController;
    private void Awake()
    {
        animController = this.GetComponent<Animator>();
    }
    private void Start()
    {
        StartCoroutine(Move());
    }
    private IEnumerator Move()
    {
        while (true)
        {
            if (Vector3.Distance(this.transform.position, RandomLocation) <= .1f)
            {
                animController.SetBool(IS_WALKING, false);
                yield return new WaitForSeconds(2f);

                RandomLocation = new Vector3(Random.Range(-9, 9), 0, Random.Range(-9, 9));

                direction = RandomLocation - this.transform.position;
                direction.Normalize();

                // Set the rotation towards the new random location
                var targetRotation = Quaternion.LookRotation(direction);

                while (transform.rotation != targetRotation)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 100f * Time.deltaTime);
                    yield return null;
                }


            }

            animController.SetBool(IS_WALKING, true);
            this.transform.position += direction * Time.deltaTime * speed;

            yield return null;
        }
    }
}

