namespace InfiniteAmmo
{
    using System;

    using Exiled.API.Features;
    using Exiled.API.Features.Items;
    using Exiled.Events.EventArgs.Player;

    /// <summary>
    /// 无限子弹: 每次射击后把弹匣补满.
    /// </summary>
    public class InfiniteAmmoPlugin : Plugin<Config>
    {
        /// <inheritdoc/>
        public override string Name => "InfiniteAmmo";

        /// <inheritdoc/>
        public override string Author => "Anonymous";

        /// <inheritdoc/>
        public override Version Version => new Version(1, 0, 0);

        /// <inheritdoc/>
        public override void OnEnabled()
        {
            Exiled.Events.Handlers.Player.Shooting += OnShooting;
            Exiled.Events.Handlers.Player.Shot += OnShot;
            base.OnEnabled();
        }

        /// <inheritdoc/>
        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Player.Shooting -= OnShooting;
            Exiled.Events.Handlers.Player.Shot -= OnShot;
            base.OnDisabled();
        }

        private void OnShooting(ShootingEventArgs ev) => Refill(ev.Firearm);

        private void OnShot(ShotEventArgs ev) => Refill(ev.Firearm);

        private static void Refill(Firearm firearm)
        {
            if (firearm == null || firearm.PrimaryMagazine == null)
                return;

            firearm.MagazineAmmo = firearm.MaxMagazineAmmo;
        }
    }
}
