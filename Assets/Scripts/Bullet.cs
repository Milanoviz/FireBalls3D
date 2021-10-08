using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core.Easing;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   [SerializeField] private float _speed;
   [SerializeField] private float _bounceFocrce;
   [SerializeField] private float _bounceRadius;
   [SerializeField] private ParticleSystem _explosionEffect;
   [SerializeField] private float _durationExplosionCamera;
   
   private Transform _mainCamera;
   private Vector3 _moveDirection;
   
   

   private void Start()
   {
      _moveDirection = Vector3.forward;
      _mainCamera = Camera.main.transform;
   }

   private void Update()
   {
      transform.Translate(_moveDirection * _speed * Time.deltaTime);
   }

   private void OnTriggerEnter(Collider other)
   {
      if (other.gameObject.TryGetComponent(out Block block))
      {
         block.Break();
         Destroy(gameObject);
      }

      if (other.gameObject.TryGetComponent(out Obstacle obstacle))
      {
         Bounce();
      }

      if (other.CompareTag("CheckBullet"))
      {
         Explosion();
      }
   }

   private void Bounce()
   {
      _moveDirection = Vector3.back + Vector3.up;
      Rigidbody rigidbody = GetComponent<Rigidbody>();
      rigidbody.isKinematic = false;
      rigidbody.AddExplosionForce(_bounceFocrce, transform.position + new Vector3(0, -1, 1), _bounceRadius);
      Destroy(gameObject, 2);
   }

   private void Explosion()
   {
      ParticleSystem explosion = Instantiate(_explosionEffect, transform.position, Quaternion.identity);
      Destroy(gameObject);
      _mainCamera.DOMoveX(_mainCamera.position.x - 2, _durationExplosionCamera).SetLoops(2, LoopType.Yoyo);
   }

}
