export default interface AthleteProfile {

    // unique user id
     id: number;

     // username, usually firstname_lastname
     username: string;

     // User's first name
     firstName: string;

     // User's surname
     lastName: string;

     // url to user's profile image, if set.
     profile: string;

     // units of measure - feet or meters (metres?)
     units: string;  // feet or metres
}
