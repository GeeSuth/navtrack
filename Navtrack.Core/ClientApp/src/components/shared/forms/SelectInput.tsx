import classNames from "classnames";
import { useFormikContext } from "formik";
import React, { ReactNode } from "react";
import { PropertyValidationResult } from "../../../services/validation/PropertyValidationResult";
import InputWrapper from "./InputWrapper";

type Props = {
  name?: string;
  value: string | number | string[];
  onChange: (event: React.ChangeEvent<HTMLSelectElement>) => void;
  validationResult?: PropertyValidationResult | undefined;
  className?: string;
  children: ReactNode;
};

export default function SelectInput(props: Props) {
  const formikContext = useFormikContext();
  const fieldMeta = formikContext.getFieldMeta(props.name ? props.name : ""); // TODO make mandatory .name

  return (
    <InputWrapper title={props.name} validationResult={props.validationResult}>
      <div className="w-full relative text-sm">
        <select
          className={classNames(
            "block appearance-none px-3 py-1 cursor-pointer border rounded-md bg-gray-100 w-full",
            { "border-red-600": fieldMeta.error && fieldMeta.touched }
          )}
          value={props.value}
          onChange={(e) => {
            props.onChange(e);
            props.validationResult?.Clear();
          }}>
          {props.children}
        </select>
        <div className="pointer-events-none absolute inset-y-0 right-0 flex items-center px-2 pt-1">
          <i className="fas fa-chevron-down" />
        </div>
      </div>
    </InputWrapper>
  );
}
