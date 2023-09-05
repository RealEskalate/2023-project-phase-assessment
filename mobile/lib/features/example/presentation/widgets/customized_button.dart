import 'package:flutter/material.dart';

class CustomizedButton extends StatelessWidget {
  final String label;
  final VoidCallback onpressed;
  const CustomizedButton({
    required this.onpressed,
    required this.label,
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    return ElevatedButton(
      onPressed: onpressed,
      child: Text(
        label,
        style: TextStyle(
          color: Colors.white,
          fontSize: 20,
        ),
      ),
      style: ElevatedButton.styleFrom(
        shape: RoundedRectangleBorder(
          borderRadius: BorderRadius.circular(12),
        ),
        padding: EdgeInsets.symmetric(horizontal: 40, vertical: 12),
        backgroundColor: Colors.blue[600],
      ),
    );
  }
}
