import 'package:flutter/material.dart';

class HomeCard extends StatelessWidget {
  const HomeCard({super.key, required this.cardData});
  final List cardData;

  @override
  Widget build(BuildContext context) {
    return SizedBox(
      height: 275,
      width: 225,
      child: Card(
        shape: RoundedRectangleBorder(
          borderRadius: BorderRadius.circular(20.0),
        ),
        margin: const EdgeInsets.all(8),
        child: Stack(
          children: [
            Positioned.fill(
              child: ClipRRect(
                borderRadius: BorderRadius.circular(20.0),
                child: Image.asset(
                  cardData[0],
                  fit: BoxFit.cover,
                ),
              ),
            ),
            Positioned(
                top: 150,
                left: 15,
                child: Container(
                  width: 180,
                  height: 90,
                  decoration: BoxDecoration(
                    borderRadius: BorderRadius.circular(20.0),
                    color: Colors.white,
                  ),
                  child: Padding(
                    padding: const EdgeInsets.all(16.0),
                    child: Column(
                      children: [
                        Text(
                          cardData[1],
                          style: const TextStyle(
                            fontSize: 20,
                            fontWeight: FontWeight.bold,
                          ),
                        ),
                        const SizedBox(
                          height: 6,
                        ),
                        Row(
                          mainAxisAlignment: MainAxisAlignment.center,
                          children: [
                            const Icon(
                              Icons.star,
                              color: Colors.amber,
                            ),
                            const SizedBox(
                              width: 4,
                            ),
                            Text(cardData[2]),
                            const SizedBox(
                              width: 12,
                            ),
                            const Icon(
                              Icons.watch_later_outlined,
                              color: Colors.blue,
                            ),
                            const SizedBox(
                              width: 4,
                            ),
                            Text(cardData[3]),
                          ],
                        )
                      ],
                    ),
                  ),
                ))
          ],
        ),
      ),
    );
  }
}

class CardList extends StatelessWidget {
  const CardList({super.key, required this.cardData, required this.onDetail});
  final List cardData;
  final VoidCallback onDetail;

  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onTap: onDetail,
      child: Container(
          margin: const EdgeInsets.symmetric(horizontal: 8, vertical: 4),
          decoration: BoxDecoration(
              borderRadius: BorderRadius.circular(12.0),
              boxShadow: [
                BoxShadow(
                  color: Colors.grey.withOpacity(0.5),
                  spreadRadius: 2.0,
                  blurRadius: 5.0,
                  offset: const Offset(0, 3),
                ),
              ],
              color: Colors.white),
          padding:
              const EdgeInsets.only(left: 24.0, top: 8, bottom: 8, right: 16),
          child: Row(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              ClipRRect(
                borderRadius: BorderRadius.circular(10.0),
                child: Image.asset(
                  cardData[0],
                  width: 130.0,
                  height: 120.0,
                  fit: BoxFit.cover,
                ),
              ),
              const SizedBox(width: 16.0),
              Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Padding(
                    padding: EdgeInsets.only(top: 20),
                    child: Text(
                      cardData[1],
                      style: const TextStyle(
                        fontSize: 22.0,
                        fontWeight: FontWeight.bold,
                      ),
                    ),
                  ),
                  SizedBox(height: 16.0),
                  Row(
                    mainAxisAlignment: MainAxisAlignment.center,
                    children: [
                      const Icon(
                        Icons.star,
                        color: Colors.amber,
                      ),
                      const SizedBox(
                        width: 4,
                      ),
                      Text(cardData[2]),
                      const SizedBox(
                        width: 12,
                      ),
                      const Icon(
                        Icons.watch_later_outlined,
                        color: Colors.blue,
                      ),
                      const SizedBox(
                        width: 4,
                      ),
                      Text(cardData[3]),
                    ],
                  )
                ],
              ),
            ],
          )),
    );
  }
}
