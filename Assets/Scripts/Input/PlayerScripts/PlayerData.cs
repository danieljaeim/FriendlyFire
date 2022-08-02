using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [Header("Movement")]
    [Range(.5f, 2f)] public float moveSpeed = 1f;
	[Space(5)]

    [Header("Movement Collisions")]
    [Range(.001f, 1f)] public float collisionOffset = 0.05f;

    [Header("Jump")]
    public float jumpForce;
    [Range(0, 1)] public float jumpCutMultiplier;
    [Space(10)]
    [Range(0, 0.5f)] public float jumpBufferTime;

	[Header("Dash")]
	public int dashAmount;
	public float dashSpeed;
	[Space(5)]
	public float dashAttackTime;
	public float dashAttackDragAmount;
	[Space(5)]
	public float dashEndTime; //time after you finish the inital drag phase, smoothing the transition back to idle (or any standard state)
	[Range(0f, 1f)] public float dashUpEndMult; //slows down player when moving up, makes dash feel more responsive (used in Celeste)
	[Range(0f, 1f)] public float dashEndRunLerp; //slows the affect of player movement while dashing
	[Space(5)]
	[Range(0, 0.5f)] public float dashBufferTime;

    [Header("Wall Jump")]
    public Vector2 wallJumpForce;
    [Space(5)]
	[Range(0f, 1f)] public float wallJumpRunLerp; //slows the affect of player movement while wall jumping
	[Range(0f, 1.5f)] public float wallJumpTime;

    [Header("Ground")]
    [Range(0, .5f)] public float coyoteTime;

    [Header("Gravity")]
    [Range(0, 1f)] public float gravityScale;
    [Range(0, 3f)] public float quickFallGravityMultiplier;
    [Range(0, 3f)] public float fallGravityMultiplier;

    [Header("Combat")]
    [Range(0, 1f)] public float timeTakenToAttack;
    [Range(0, 1f)] public float attackTimerWait;
    [Range(0, 5f)] public float attackDamage;

    [Header("Other Settings")]
    public bool doKeepRunMomentum;
    public bool doTurnOnWallJump;
}
