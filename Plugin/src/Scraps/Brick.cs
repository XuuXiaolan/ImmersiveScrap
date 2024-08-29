using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ImmersiveScrap.Configs;
using ImmersiveScrap.Misc;
using Unity.Netcode;
using UnityEngine;


namespace ImmersiveScrap.Scrap;
public class Brick : ThrowableNoisemaker {
    public AudioClip[] cookieSpecialAudio;
    public AudioSource brickPlayer;
    private float explodePercentage = 100;
    public bool wasThrown = false;
    private System.Random noiseMakerRandom;
    public override void Start() {
        base.Start();
        noiseMakerRandom = new System.Random(StartOfRound.Instance.randomMapSeed + 85);
    }
    public void DetectThrowKeyPressed() {
        if (!Plugin.InputActionsInstance.ThrowKey.triggered || playerHeldBy != GameNetworkManager.Instance.localPlayerController) return;
        wasThrown = true;
        var rotationStuff = GetItemThrowDestination();
        playerHeldBy.DiscardHeldObject(placeObject: true, null, rotationStuff);
        PlayCookieAudioServerRpc(0);
    }
    public override void Update() {
        base.Update();
        if (playerHeldBy == null || playerHeldBy.currentlyHeldObjectServer != this) return;
        DetectThrowKeyPressed();
    }

    [ServerRpc]
    public void PlayCookieAudioServerRpc(int index) {
        PlayCookieAudioClientRpc(index);
    }

    [ClientRpc]
    public void PlayCookieAudioClientRpc(int index) {
        if (cookieSpecialAudio.Length == 0) return;
        brickPlayer.PlayOneShot(cookieSpecialAudio[index]);

        WalkieTalkie.TransmitOneShotAudio(brickPlayer, cookieSpecialAudio[index], 0.5f);
        RoundManager.Instance.PlayAudibleNoise(base.transform.position, 15, 0.5f, 0, isInElevator && StartOfRound.Instance.hangarDoorsClosed);
    }

    [ServerRpc]
    public void StopPlayingCookieAudioServerRpc() {
        StopPlayingCookieAudioClientRpc();
    }

    [ClientRpc]
    public void StopPlayingCookieAudioClientRpc() {
        brickPlayer.Stop();
    }


    [ClientRpc]
    public void BoomClientRpc() {
        Boom();
    }

    [ServerRpc]
    public void BoomServerRpc() {
        Boom();
        BoomClientRpc();
    }


    public void CreateExplosion() {
        var player = StartOfRound.Instance.allPlayerScripts.FirstOrDefault(x => x.OwnerClientId == OwnerClientId);
        int dealtDamage = 0;
        if (ImmersiveScrapConfig.ConfigBrickDealingDamage.Value) dealtDamage = ImmersiveScrapConfig.ConfigBrickDealingXDamage.Value;
        Utilities.CreateExplosion(transform.position, ImmersiveScrapConfig.ConfigBrickExploding.Value, 20, 0, dealtDamage, 2, CauseOfDeath.Blast, player);
    }

    public void Boom() {
        CreateExplosion();
    }

    public override void OnHitGround() {
        if (wasThrown) {
            wasThrown = false;
            if (IsOwner) {
                if (noiseMakerRandom.Next(0, 101) <= explodePercentage) {
                    Boom();
                    BoomServerRpc();
                }
            }
        }
    }
}