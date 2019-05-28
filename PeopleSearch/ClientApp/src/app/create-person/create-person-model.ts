import { CreateAddressModel } from "./create-address-model";

export class CreatePersonModel {
  public firstName: string;
  public lastName: string;
  public age: number;
  public interests: string;
  public pictureUrl: string;
  public address: CreateAddressModel = new CreateAddressModel();
}
