import 'package:flutter/material.dart';

import '../../../../core/presentation/theme/app_colors.dart';

class CustomTextField extends StatelessWidget {
  final String? label;
  final TextInputType? keyboardType;
  final int? minLines;
  final int? maxLines;
  final int? maxLength;
  final TextEditingController? controller;
  final String? Function(String?)? validator;

  const CustomTextField({
    super.key,
    this.label,
    this.controller,
    this.keyboardType,
    this.maxLines,
    this.minLines,
    this.maxLength,
    this.validator,
  });

  @override
  Widget build(BuildContext context) {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        if (label != null)
          Text(
            label!,
            style: Theme.of(context).textTheme.bodyMedium?.copyWith(
                  color: Theme.of(context).colorScheme.primary,
                  fontWeight: FontWeight.w600,
                ),
          ),
        const SizedBox(height: 10),
        Container(
          decoration: BoxDecoration(
            color: Theme.of(context).colorScheme.background,
            borderRadius: BorderRadius.circular(16),
            boxShadow: [
              BoxShadow(
                color: Theme.of(context).colorScheme.surface.withOpacity(.5),
                blurRadius: 10,
                offset: const Offset(0, 5),
              ),
            ],
          ),
          child: TextFormField(
            controller: controller,
            keyboardType: keyboardType,
            minLines: minLines,
            maxLines: maxLines,
            maxLength: maxLength,
            validator: validator,
            style: Theme.of(context).textTheme.bodyMedium,
            decoration: InputDecoration(
              border: InputBorder.none,
              contentPadding:
                  const EdgeInsets.symmetric(horizontal: 20, vertical: 15),
              hintText: label ?? '',
              hintStyle: const TextStyle(
                color: AppColors.gray300,
                fontFamily: 'Poppins',
                fontSize: 18,
                fontWeight: FontWeight.w200,
              ),
            ),
          ),
        ),
      ],
    );
  }
}
