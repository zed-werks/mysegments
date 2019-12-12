export class AthleteProfile {
  constructor(
    public updated: Date,
    public id: number,
    public username: string,
    public firstname: string,
    public lastname: string,
    public city: string,
    public state: string,
    public country: string,
    public profile: string, // url to the image.
    public measurementPreference: string,  // feet or metres
  ) {}
}
