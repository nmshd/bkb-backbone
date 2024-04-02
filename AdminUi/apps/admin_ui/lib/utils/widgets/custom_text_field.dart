import 'package:flutter/material.dart';

import '/utils/utils.dart';

class CustomTextField extends StatelessWidget {
  final TextEditingController controller;
  final FocusNode focusNode;
  final String label;
  final bool obscureText;
  final String? errorText;
  final void Function(String) onChanged;
  final void Function(String) onSubmitted;

  const CustomTextField({
    required this.controller,
    required this.focusNode,
    required this.label,
    required this.onChanged,
    required this.onSubmitted,
    this.obscureText = false,
    this.errorText,
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    return TextField(
      controller: controller,
      focusNode: focusNode,
      decoration: InputDecoration(
        labelText: label,
        border: const OutlineInputBorder(),
        errorBorder: OutlineInputBorder(
          borderSide: BorderSide(color: context.customColors.error ?? Colors.red, width: 2),
        ),
        focusedErrorBorder: OutlineInputBorder(
          borderSide: BorderSide(color: context.customColors.error ?? Colors.red, width: 2),
        ),
        errorText: errorText,
      ),
      obscureText: obscureText,
      onChanged: onChanged,
      onSubmitted: onSubmitted,
    );
  }
}
