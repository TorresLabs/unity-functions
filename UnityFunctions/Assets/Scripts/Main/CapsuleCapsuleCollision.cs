﻿using System;
using Extensions;
using Unianio.Extensions;
using UnityEngine;
using UnityFunctions;

namespace Main
{
    public class CapsuleCapsuleCollision : BaseMainScript
    {
//        private const float CapsuleRadius1 = 0.12f;
//        private const float CapsuleRadius2 = 0.2f;
//        private const float CapsuleHeight1 = 0.8f;
//        private const float CapsuleHeight2 = 0.6f;
        private const float CapsuleRadius1 = 0.14f;
        private const float CapsuleRadius2 = 0.06f;
        private const float CapsuleHeight1 = 0.4f;
        private const float CapsuleHeight2 = 0.8f;
        private Transform[] _capsule1,_capsule2;
        private Transform _collision;

        void Start ()
	    {
            _capsule1 = CreateCapsule(CapsuleRadius1,CapsuleHeight1);
            _capsule2 = CreateCapsule(CapsuleRadius2,CapsuleHeight2);
            _capsule1[0].name = "capsule_1";
            _capsule2[0].name = "capsule_2";
            _capsule2[0].position += Vector3.forward*0.5f;
            _collision = 
                fun.meshes.CreateSphere(new DtSphere {radius = 0.03,name = "collision"})
                    .SetStandardShaderTransparentColor(1,0,0,0.9).transform;

	    }

        void Update()
        {
            var radius1 = CapsuleRadius1;
            var radius2 = CapsuleRadius2;
            var height1 = CapsuleHeight1;
            var height2 = CapsuleHeight2;
            var c1p1 = _capsule1[0].position - _capsule1[0].up*(height1/2 - radius1);
            var c1p2 = _capsule1[0].position + _capsule1[0].up*(height1/2 - radius1);
            var c2p1 = _capsule2[0].position - _capsule2[0].up*(height2/2 - radius2);
            var c2p2 = _capsule2[0].position + _capsule2[0].up*(height2/2 - radius2);

            
            // test code STARTS here -----------------------------------------------
            Vector3 collision;
            var hasCollision = 
                fun.intersection.BetweenCapsules(
                    ref c1p1, ref c1p2, radius1, 
                    ref c2p1, ref c2p2, radius2, out collision);
            // test code ENDS here -------------------------------------------------

            _collision.position = hasCollision ? collision : new Vector3(0,999,0);

            SetColorOnChanged(hasCollision, rgba(0, 1, 0, 0.5), rgba(0.5,0.5,0.5,0.5), _capsule1);
            SetColorOnChanged(hasCollision, rgba(0, 1, 0, 0.5), rgba(0.5,0.5,0.5,0.5), _capsule2);
        }

        

        


    }
}