namespace GymBackend.Domain.Users;

/// <summary>
/// Default characteristics.
/// </summary>
public static class DefaultCharacteristics
{
    #region General

    /// <summary>
    /// Weight.
    /// </summary>
    public const string Weight = "Weight";

    /// <summary>
    /// Height.
    /// </summary>
    public const string Height = "Height";

    #endregion

    #region Core

    /// <summary>
    /// Waist.
    /// </summary>
    public const string Waist = "Waist";

    /// <summary>
    /// Chest.
    /// </summary>
    public const string Chest = "Chest";

    /// <summary>
    /// Neck.
    /// </summary>
    public const string Neck = "Neck";

    /// <summary>
    /// Hips.
    /// </summary>
    public const string Hips = "Hips";

    /// <summary>
    /// Belly.
    /// </summary>
    public const string Belly = "Belly";

    /// <summary>
    /// Pelvis.
    /// </summary>
    public const string Pelvis = "Pelvis";

    /// <summary>
    /// Shoulders.
    /// </summary>
    public const string Shoulders = "Shoulders";

    #endregion

    #region Arms

    /// <summary>
    /// Left shoulder.
    /// </summary>
    public const string LeftBiceps = "Left biceps";

    /// <summary>
    /// Right shoulder.
    /// </summary>
    public const string RightBiceps = "Right biceps";

    /// <summary>
    /// Left forearm.
    /// </summary>
    public const string LeftForearm = "Left forearm";

    /// <summary>
    /// Right forearm.
    /// </summary>
    public const string RightForearm = "Right forearm";

    /// <summary>
    /// Left wrist.
    /// </summary>
    public const string LeftWrist = "Left wrist";

    /// <summary>
    /// Right wrist.
    /// </summary>
    public const string RightWrist = "Right wrist";

    #endregion

    /// <summary>
    /// Get all default characteristics.
    /// </summary>
    /// <returns>All default characteristics.</returns>
    public static IEnumerable<string> GetAll()
    {
        return new[]
        {
            Weight,
            Height,
            Waist,
            Chest,
            Neck,
            Hips,
            Belly,
            Pelvis,
            Shoulders,
            LeftBiceps,
            RightBiceps,
            LeftForearm,
            RightForearm,
            LeftWrist,
            RightWrist
        };
    }
}
